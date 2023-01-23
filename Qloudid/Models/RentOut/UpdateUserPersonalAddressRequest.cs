namespace Qloudid.Models
{
    public class UpdateUserPersonalAddressRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "booking_id")]
        public int BookingId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_company")]
        public int IsCompany { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "d_address")]
        public string D_Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dcity")]
        public string D_City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dzip")]
        public string D_Zip { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dpo_number")]
        public string D_PoNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_number")]
        public string CardNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "expiry_month")]
        public string ExpiryMonth { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "expiry_year")]
        public string ExpiryYear { get; set; }
    }
}
