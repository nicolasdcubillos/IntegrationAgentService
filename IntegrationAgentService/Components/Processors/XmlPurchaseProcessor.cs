using IntegrationAgentService.Models.AttachedDocumentSchema;
using IntegrationAgentService.Models.InvoiceSchema;
using System.Xml.Serialization;

namespace IntegrationAgentService.Components.Processors
{
    public class XmlPurchaseProcessor : IFileProcessor
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public XmlPurchaseProcessor(ILogger logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void Process(string content, string filePath)
        {
            dynamic vfp = null;
            try
            {
                AttachedDocument attachedDocument = LoadAttachedDocument(filePath);
                Invoice invoice = attachedDocument.Attachment.ExternalReference.Invoice;

                if (attachedDocument != null)
                {
                    _logger.LogInformation($"[XmlPurchaseProcessor] Factura ");

                    vfp = Activator.CreateInstance(Type.GetTypeFromProgID("VisualFoxPro.Application"));
                    if (vfp == null)
                    {
                        throw new Exception("No se pudo crear la instancia de Visual FoxPro.");
                    }

                    string procedurePath = _config["ServiceConfig:TradeDataInserterPath"];
                    if (procedurePath == null)
                    {
                        throw new ArgumentNullException("TradeDataInserterPath not found in configuration.");
                    }

                    vfp.DoCmd($@"SET PROCEDURE TO '{procedurePath}' ADDITIVE");
                    //var resultado = vfp.Eval("saveTrade", attachedDocument);

                    _logger.LogInformation($"[XmlPurchaseProcessor] Calling VFP... ");
                }
                else
                {
                    _logger.LogWarning($"[XmlPurchaseProcessor] No se pudo procesar el archivo: {filePath}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[XmlPurchaseProcessor] Error al procesar: {filePath}");
            }
            finally
            {
                vfp?.Quit();
            }
        }

        public static AttachedDocument LoadAttachedDocument(string filePath)
        {
            XmlSerializer attachedDocumentSerializer = new XmlSerializer(typeof(AttachedDocument));

            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            AttachedDocument document = (AttachedDocument)attachedDocumentSerializer.Deserialize(stream);

            XmlSerializer invoiceSerializer = new XmlSerializer(typeof(Invoice));
            using var reader = new StringReader(document.Attachment.ExternalReference.Description);
            Invoice invoice = (Invoice)invoiceSerializer.Deserialize(reader);
            document.Attachment.ExternalReference.Invoice = invoice;

            return document;
        }
    }
}
