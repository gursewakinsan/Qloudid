namespace Qloudid.Models
{
    public class CheckPhoneInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
    }
}