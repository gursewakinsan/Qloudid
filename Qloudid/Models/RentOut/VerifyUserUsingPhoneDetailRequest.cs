namespace Qloudid.Models
{
    public class VerifyUserUsingPhoneDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "uphno")]
        public string PhoneNumber { get; set; }
    }
}
