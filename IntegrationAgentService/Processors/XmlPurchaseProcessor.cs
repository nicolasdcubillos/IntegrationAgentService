using IntegrationAgentService.Models.AttachedDocumentSchema;
using IntegrationAgentService.Models.InvoiceSchema;
using System.Xml.Serialization;

namespace IntegrationAgentService.Processors
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

        public AttachedDocument Process(string content, string filePath)
        {
            try
            {
                return LoadAttachedDocument(filePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[XmlPurchaseProcessor] Error al procesar: {filePath}");
            }

            return null;
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
