namespace Qloudid.Models
{
    public class GetServiceInvoiceDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "invoice_id")]
        public string InvoiceId { get; set; }
    }
}
