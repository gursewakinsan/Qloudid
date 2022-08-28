namespace Qloudid.Models
{
    public class AddVisitingCountryRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "IssueDate")]
        public string IssueDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ExpiryDate")]
        public string ExpiryDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "identificator_type")]
        public int IdentificatorType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id_number")]
        public string IdNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "p_number")]
        public string PNumber { get; set; }
    }
}