// agregar referencias
using IntegrationAgentService.Models.AttachedDocumentSchema;
using IntegrationAgentService.Processors;
using IntegrationAgentService.Repository;

public class PurchaseInterface
{
    private readonly ILogger _logger;
    private readonly IConfiguration _config;
    private readonly string _inputFolder;
    private readonly string _processedFolder;
    private readonly Dictionary<string, IFileProcessor> _processors;
    private readonly string _connectionString;
    private readonly IEntityTranslator _entityTranslator;
    private readonly SqlRepository _sqlRepository;

    public PurchaseInterface(ILogger logger, IConfiguration config, string connectionString)
    {
        _logger = logger;
        _config = config;
        _connectionString = connectionString;

        _inputFolder = _config["ServiceConfig:Interfaces:Purchase:WatchFolder"]
            ?? throw new ArgumentNullException("WatchFolder not found");

        _processedFolder = _config["ServiceConfig:Interfaces:Purchase:ProcessedFolder"]
            ?? throw new ArgumentNullException("ProcessedFolder not found");

        Directory.CreateDirectory(_inputFolder);
        Directory.CreateDirectory(_processedFolder);

        _processors = new Dictionary<string, IFileProcessor>(StringComparer.OrdinalIgnoreCase)
        {
            { ".xml", new XmlPurchaseProcessor(_logger, _config) },
            { ".json", new JsonPurchaseProcessor(_logger, _config) }
        };

        string documentMappingPath = _config["ServiceConfig:Interfaces:Purchase:DocumentMappingPath"]
            ?? throw new ArgumentNullException("DocumentMappingPath not found");

        _entityTranslator = new EntityTranslator(documentMappingPath);
        _sqlRepository = new SqlRepository(_connectionString);
    }

    public async Task Execute()
    {
        var files = Directory.GetFiles(_inputFolder, "*.*")
                             .Where(f => _processors.ContainsKey(Path.GetExtension(f)));

        foreach (var file in files)
        {
            try
            {
                _logger.LogInformation($"[PurchaseInterface] Processing {file}");

                // 1. Scanning all files in the input folder

                var ext = Path.GetExtension(file).ToLowerInvariant();
                var content = File.ReadAllText(file);

                // 2. Processing the file based on its extension 

                AttachedDocument attachedDocument = _processors[ext].Process(content, file);

                Thread.Sleep(500);

                // 3. Moving the file to the processed folder

                var dest = Path.Combine(_processedFolder, Path.GetFileName(file));
                //File.Move(file, dest, true);
                _logger.LogInformation($"[PurchaseInterface] Moved to {dest}");

                // 4. Translating the xml object file to database schema

                Dictionary<string, object> tradeData = _entityTranslator.Translate(attachedDocument, "Trade");
                Dictionary<string, object> mvTradeData = _entityTranslator.Translate(attachedDocument, "MvTrade");

                // 5. Persisting information in the database and bussiness logic
                
                var mtprocliQuery = await _sqlRepository.SelectAsync("Mtprocli", $"NIT = '{attachedDocument.SenderParty.PartyTaxScheme.CompanyID.Text}'");
                if (mtprocliQuery.Count == 0)
                {
                    Dictionary<string, object> mtprocliData = _entityTranslator.Translate(attachedDocument, "Mtprocli");
                    mtprocliData.Add("Pais", "169");
                    mtprocliData.Add("Fechaing", DateTime.Now);
                    mtprocliData.Add("Medpag", 0);
                    await _sqlRepository.InsertAsync("Mtprocli", mtprocliData);
                }

                await _sqlRepository.InsertAsync("Trade", tradeData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[PurchaseInterface] Failed to process {file}");
            }
        }
    }
}
