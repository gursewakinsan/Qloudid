namespace Qloudid.Models
{
    public class UpdateBlockedRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; set; }
    }
}
