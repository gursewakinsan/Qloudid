namespace Qloudid.Models
{
    public class UpdateServiceInvoicePaymentDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "invoice_id")]
        public string InvoiceId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_user")]
        public int IsUser { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "buyer_id")]
        public int BuyerId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_id")]
        public int CardId { get; set; }
    }
}