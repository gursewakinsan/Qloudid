namespace Qloudid.Models
{
    public class CheckPassportInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id_number")]
        public string IdNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }
    }
}
