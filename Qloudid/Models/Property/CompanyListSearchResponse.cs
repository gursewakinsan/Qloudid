namespace Qloudid.Models
{
    public class CompanyListSearchResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_email")]
        public string CompanyEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}
