using IntegrationAgentService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Xml;

namespace IntegrationAgentService.Components.Processors
{
    public class XmlPurchaseProcessor : IFileProcessor
    {
        private readonly ILogger _logger;

        public XmlPurchaseProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public void Process(string content, string filePath)
        {
            try
            {
                var invoice = ExtractInvoiceModelFromAttachedDocument(content);

                if (invoice != null)
                {
                    _logger.LogInformation($"[XmlPurchaseProcessor] Factura: {invoice.InvoiceNumber} - Cliente: {invoice.Customer?.Name} - Total: {invoice.TotalAmount}");
                    // TODO: Lógica futura para enviar a FoxPro o DB
                }
                else
                {
                    _logger.LogWarning($"[XmlPurchaseProcessor] No se pudo procesar el archivo: {filePath}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[XmlPurchaseProcessor] Failed to process: {filePath}");
            }
        }

        private InvoiceModel? ExtractInvoiceModelFromAttachedDocument(string xmlContent)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xmlContent);

            // 1. Extraer el contenido del nodo CDATA donde está el <Invoice>
            var descriptionNode = doc.SelectSingleNode("//*[local-name()='Description']");
            if (descriptionNode == null || string.IsNullOrWhiteSpace(descriptionNode.InnerText))
            {
                _logger.LogWarning("[XmlPurchaseProcessor] No se encontró el nodo <Description> con el XML embebido.");
                return null;
            }

            var innerXml = descriptionNode.InnerText.Trim();

            // 2. Parsear el contenido como nuevo XML
            var invoiceDoc = new XmlDocument();
            invoiceDoc.LoadXml(innerXml);

            // 3. Extraer datos principales (puedes ampliar esto luego)
            var invoice = new InvoiceModel();

            invoice.InvoiceNumber = invoiceDoc.SelectSingleNode("//*[local-name()='ID']")?.InnerText ?? "";
            invoice.IssueDate = DateTime.TryParse(invoiceDoc.SelectSingleNode("//*[local-name()='IssueDate']")?.InnerText, out var date) ? date : DateTime.MinValue;
            invoice.Currency = invoiceDoc.SelectSingleNode("//*[local-name()='DocumentCurrencyCode']")?.InnerText ?? "";
            invoice.TotalAmount = decimal.TryParse(invoiceDoc.SelectSingleNode("//*[local-name()='LegalMonetaryTotal']//*[local-name()='PayableAmount']")?.InnerText, out var total) ? total : 0;

            // Cliente
            var customerNode = invoiceDoc.SelectSingleNode("//*[local-name()='AccountingCustomerParty']//*[local-name()='PartyName']//*[local-name()='Name']");
            var taxIdNode = invoiceDoc.SelectSingleNode("//*[local-name()='AccountingCustomerParty']//*[local-name()='PartyTaxScheme']//*[local-name()='CompanyID']");

            invoice.Customer = new PartyModel
            {
                Name = customerNode?.InnerText ?? "",
                TaxId = taxIdNode?.InnerText ?? ""
            };

            return invoice;
        }
    }
}
