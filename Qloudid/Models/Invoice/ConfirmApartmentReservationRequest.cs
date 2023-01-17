namespace Qloudid.Models
{
    public class ConfirmApartmentReservationRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "property_id")]
        public string PropertyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_company")]
        public int IsCompany { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_id")]
        public int CardId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address_id")]
        public int InvoiceAddressId { get; set; }
    }
}
