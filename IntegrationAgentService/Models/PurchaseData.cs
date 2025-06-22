using System.Xml.Serialization;

namespace IntegrationAgentService.Models
{
    public class InvoiceModel
    {
        public string Uuid { get; set; }                    // CUFE
        public string InvoiceNumber { get; set; }           // <cbc:ID>
        public DateTime IssueDate { get; set; }             // <cbc:IssueDate>
        public TimeSpan IssueTime { get; set; }             // <cbc:IssueTime>
        public string Currency { get; set; }                // <cbc:DocumentCurrencyCode>

        public PartyModel Supplier { get; set; }
        public PartyModel Customer { get; set; }

        public decimal TaxAmount { get; set; }              // <cbc:TaxAmount>
        public decimal TotalAmount { get; set; }            // <cbc:PayableAmount>
        public List<InvoiceLineModel> Items { get; set; }
    }

    public class PartyModel
    {
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }

    public class InvoiceLineModel
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    [XmlRoot("Purchase")]
    public class PurchaseData
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
    }
}
