using IntegrationAgentService.Models.AttachedDocumentSchema;
using IntegrationAgentService.Models.InvoiceSchema;
using IntegrationAgentService.Processors;
using IntegrationAgentService.ProductServiceClassifier;
using IntegrationAgentService.Repository;
using Microsoft.Data.SqlClient;

public class PurchaseInterface
{
    private readonly ILogger _logger;
    private readonly IConfiguration _config;
    private readonly string _inputFolder;
    private readonly string _processedFolder;
    private readonly string _errorsFolder;
    private readonly Dictionary<string, IFileProcessor> _processors;
    private readonly string _connectionString;
    private readonly IEntityTranslator _entityTranslator;
    private readonly SqlRepository _sqlRepository;
    private readonly string _tipodcto;
    private ClassifierML _classifier;
    private string nit;

    public PurchaseInterface(ILogger logger, IConfiguration config, string connectionString)
    {
        _logger = logger;
        _config = config;
        _connectionString = connectionString;

        _inputFolder = _config["ServiceConfig:Interfaces:Purchase:WatchFolder"]
            ?? throw new ArgumentNullException("WatchFolder not found");

        _processedFolder = _config["ServiceConfig:Interfaces:Purchase:ProcessedFolder"]
            ?? throw new ArgumentNullException("ProcessedFolder not found");

        _errorsFolder = _config["ServiceConfig:Interfaces:Purchase:ErrorsFolder"]
            ?? throw new ArgumentNullException("ErrorsFolder not found");

        Directory.CreateDirectory(_inputFolder);
        Directory.CreateDirectory(_processedFolder);
        Directory.CreateDirectory(_errorsFolder);

        _processors = new Dictionary<string, IFileProcessor>(StringComparer.OrdinalIgnoreCase)
        {
            { ".xml", new XmlPurchaseProcessor(_logger, _config) },
            { ".json", new JsonPurchaseProcessor(_logger, _config) }
        };

        string documentMappingPath = _config["ServiceConfig:Interfaces:Purchase:DocumentMappingPath"]
            ?? throw new ArgumentNullException("DocumentMappingPath not found");

        _entityTranslator = new EntityTranslator(documentMappingPath);
        _sqlRepository = new SqlRepository(_connectionString);
        _tipodcto = _config["ServiceConfig:Interfaces:Purchase:TipoDcto"]
            ?? throw new ArgumentNullException("TipoDcto not found");

        if (bool.TryParse(_config["ServiceConfig:Interfaces:Purchase:MLTrainingEnabled"], out var mlTrainingEnabled) && mlTrainingEnabled)
        {
            _logger.LogInformation("[PurchaseInterface] ML Training is enabled.");
            StartProductServiceClassifierML();
        }
        else
        {
            _logger.LogInformation("[PurchaseInterface] ML Training is disabled.");
        }
    }

    private void StartProductServiceClassifierML()
    {
        string modelPath = _config["ServiceConfig:Interfaces:Purchase:MLModelPath"]
            ?? throw new ArgumentNullException("MLModelPath not found");

        if (File.Exists(modelPath))
        {
            _classifier = new ClassifierML(modelPath);
            Console.WriteLine($"Modelo existente cargado desde: {modelPath}");
        }
        else
        {
            _logger.LogInformation("ML Training starting.");
            var entrenador = new TrainerML();
            var trainingDataList = GetTrainingData();
            entrenador.TrainAndSaveModel(modelPath, trainingDataList);

            _classifier = new ClassifierML(modelPath);
            Console.WriteLine($"Modelo entrenado y guardado en: {modelPath}");
        }
    }

    public async Task Execute()
    {
        var files = Directory.GetFiles(_inputFolder, "*.*")
                             .Where(f => _processors.ContainsKey(Path.GetExtension(f)));

        foreach (var file in files)
        {
            try
            {
                _logger.LogInformation($"[PurchaseInterface] Procesando {file}");

                // 1. Scanning all files in the input folder

                var ext = Path.GetExtension(file).ToLowerInvariant();
                var content = File.ReadAllText(file);

                // 2. Processing the file based on its extension 

                AttachedDocument attachedDocument = _processors[ext].Process(content, file);

                if (attachedDocument == null)
                {
                    throw new Exception("Attached document null.");
                }

                Thread.Sleep(500);

                // 3. Translating the xml object file to database schema

                Dictionary<string, object> tradeData = _entityTranslator.Translate(attachedDocument, "TRADE");
                Dictionary<string, object> mtprocliData = _entityTranslator.Translate(attachedDocument, "MTPROCLI");

                // 4. Persisting information in the database and business logic

                string nit = attachedDocument.SenderParty.PartyTaxScheme.CompanyID.Text;
                if (nit == null)
                {
                    throw new Exception("NIT is null or empty in the attached document.");
                }
                nit += "-" + CalcularDigitoVerificacion(nit);

                // Transaction management

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int consecut = GetConsecutForTipoDcto();
                            UpdateConsecutForTipoDcto(consecut);
                            SaveMtprocliData(file, attachedDocument, nit, mtprocliData);
                            SaveTradeData(file, attachedDocument, tradeData, consecut);
                            SaveMvTradeData(file, attachedDocument, consecut);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"[PurchaseInterface] Error al guardar datos para {file}: {ex.Message}");
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                // 5. Moving the file to the processed folder

                var dest = Path.Combine(_processedFolder, Path.GetFileName(file));
                File.Move(file, dest, true);
                _logger.LogInformation($"[PurchaseInterface] Procesado y movido a {dest}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[PurchaseInterface] Error al procesar {file}: {ex.Message}");
                var destErrors = Path.Combine(_errorsFolder, Path.GetFileName(file));
                File.Move(file, destErrors, true);
            }
        }
    }

    private List<ProductInput> GetTrainingData()
    {
        var resultado = _sqlRepository.SelectAsync("MTMERCIA").GetAwaiter().GetResult(); ;

        var lista = new List<ProductInput>();

        foreach (var fila in resultado)
        {
            var codigo = fila.ContainsKey("CODIGO") ? fila["CODIGO"]?.ToString() ?? "" : "";
            var descripcio = fila.ContainsKey("DESCRIPCIO") ? fila["DESCRIPCIO"]?.ToString() ?? "" : "";

            if (!string.IsNullOrWhiteSpace(codigo) && !string.IsNullOrWhiteSpace(descripcio))
            {
                lista.Add(new ProductInput
                {
                    ServiceCode = codigo,
                    Description = descripcio
                });
            }
        }

        return lista;
    }

    private void SaveMtprocliData(string file, AttachedDocument attachedDocument, string nit, Dictionary<string, object> mtprocliData)
    {
        var mtprocliQuery = _sqlRepository.SelectAsync("MTPROCLI", $"NIT = '{nit}'").GetAwaiter().GetResult();
        if (mtprocliQuery.Count == 0)
        {
            string countryIdentificationCode = attachedDocument.Attachment.ExternalReference.Invoice.AccountingSupplierParty.Party.PartyTaxScheme.RegistrationAddress.Country.IdentificationCode.Text;
            if (countryIdentificationCode != null)
            {
                var mtpaisQuery = _sqlRepository.SelectAsync("MTPAISES", $"ISO_3166_1 = '{countryIdentificationCode}'").GetAwaiter().GetResult();
                string paisCodigo = mtpaisQuery.FirstOrDefault()?["CODIGO"]?.ToString();
                if (paisCodigo != null)
                {
                    mtprocliData.Add("PAIS", paisCodigo);
                }
                else
                {
                    _logger.LogWarning($"[PurchaseInterface] Country code not found for {countryIdentificationCode} in Mtpaises table for file {file}.");
                }
            }
            else
            {
                _logger.LogWarning($"[PurchaseInterface] Country identification code is null for file {file}.");
            }

            string? cdciiu = attachedDocument.Attachment.ExternalReference.Invoice.AccountingSupplierParty.Party.PartyTaxScheme.RegistrationAddress.ID.Text ?? "";
            if (cdciiu != null && cdciiu.Length == 5)
            {
                string ciudadCodigo = cdciiu.Substring(3, 2);
                mtprocliData.Add("CIUDAD", ciudadCodigo);
            }
            else
            {
                _logger.LogWarning($"[PurchaseInterface] Invalid or missing city code in {cdciiu} for file {file}.");
            }

            string? telephone = attachedDocument.Attachment.ExternalReference.Invoice.AccountingSupplierParty.Party.Contact.Telephone;
            if (telephone != null)
            {
                string[] parts = telephone.Split('|');
                string tel1 = parts.Length > 0 ? parts[0] : "";
                string tel2 = parts.Length > 1 ? parts[1] : "";
                mtprocliData.Add("TEL1", tel1);
                mtprocliData.Add("TEL2", tel2);
            }
            else
            {
                _logger.LogWarning($"[PurchaseInterface] Telephone is null or empty in the attached document for file {file}.");
            }

            mtprocliData.Add("FECHAING", DateTime.Now);
            mtprocliData.Add("MEDPAG", 0);
            mtprocliData["NIT"] = nit; // Actualizando el NIT con el dígito de verificación

            _sqlRepository.InsertAsync("MTPROCLI", mtprocliData).GetAwaiter().GetResult();
        }
    }

    private void SaveTradeData(string file, AttachedDocument attachedDocument, Dictionary<string, object> tradeData, int consecut)
    {
        tradeData["NIT"] = nit;
        tradeData.Add("TIPODCTO", _tipodcto);
        tradeData.Add("NRODCTO", consecut);
        _sqlRepository.InsertAsync("TRADE", tradeData).GetAwaiter().GetResult();
    }

    private void SaveMvTradeData(string file, AttachedDocument attachedDocument, int consecut)
    {
        Dictionary<string, object> mvTradeData = _entityTranslator.Translate(attachedDocument, "MVTRADE");
        mvTradeData.Add("TIPODCTO", _tipodcto);
        mvTradeData.Add("NRODCTO", consecut);
        mvTradeData["NIT"] = nit;

        foreach (InvoiceLine invoiceLine in attachedDocument.Attachment.ExternalReference.Invoice.InvoiceLine)
        {
            Dictionary<string, object> mvTradeDataInvoiceLine = _entityTranslator.Translate(invoiceLine, "MVTRADE");
            foreach (var kvp in mvTradeDataInvoiceLine)
            {
                if (!mvTradeData.ContainsKey(kvp.Key) || mvTradeData[kvp.Key] == null || string.IsNullOrWhiteSpace(mvTradeData[kvp.Key]?.ToString()))
                {
                    mvTradeData[kvp.Key] = kvp.Value;
                }
            }
            //_sqlRepository.InsertAsync("MVTRADE", mvTradeData).GetAwaiter().GetResult();
        }
    }

    private int GetConsecutForTipoDcto()
    {
        int consecut = 0;
        var consecutQuery = _sqlRepository.SelectAsync("CONSECUT", $"TIPODCTO = '{_tipodcto}' AND ORIGEN = 'COM'").GetAwaiter().GetResult();
        string consecutString = consecutQuery.FirstOrDefault()?["CONSECUT"]?.ToString();
        if (!string.IsNullOrWhiteSpace(consecutString))
        {
            int.TryParse(consecutString, out consecut);
        } else
        {
            throw new Exception($"Consecutive not found for TipoDcto {_tipodcto} in CONSECUT table.");
        }
        return consecut;
    }

    private void UpdateConsecutForTipoDcto(int consecut)
    {
        var consecutData = new Dictionary<string, object>
        {
            { "CONSECUT", consecut + 1 }
        };

        _sqlRepository.UpdateAsync("CONSECUT", consecutData, $"TIPODCTO = '{_tipodcto}'").GetAwaiter().GetResult();
    }

    public string CalcularDigitoVerificacion(string nit)
    {
        if (string.IsNullOrWhiteSpace(nit) || !nit.All(char.IsDigit))
            throw new ArgumentException("El NIT debe contener solo números.");

        int[] pesos = { 71, 67, 59, 53, 47, 43, 41, 37, 29, 23, 19, 17, 13, 7, 3 };
        int suma = 0;
        int longitud = nit.Length;

        for (int i = 0; i < longitud; i++)
        {
            int digito = int.Parse(nit[longitud - 1 - i].ToString());
            suma += digito * pesos[i];
        }

        int residuo = suma % 11;
        int digitoVerificacion = (residuo > 1) ? 11 - residuo : residuo;
        return digitoVerificacion.ToString();
    }
}
