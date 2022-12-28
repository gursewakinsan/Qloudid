namespace Qloudid.Models
{
    public class GetBlockedDatesRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
