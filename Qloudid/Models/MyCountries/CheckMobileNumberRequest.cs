namespace Qloudid.Models
{
    public class CheckMobileNumberRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "p_number")]
        public string PhoneNumber { get; set; }
    }
}
