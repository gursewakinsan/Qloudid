namespace Qloudid.Models
{
    public class VerifyUserUsingPhoneDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }
    }
}
