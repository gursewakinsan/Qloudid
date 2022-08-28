namespace Qloudid.Models
{
    public class CurrentCountryDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "default_country")]
        public int DefaultCountry { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "current_country")]
        public bool CurrentCountry { get; set; }
    }
}
