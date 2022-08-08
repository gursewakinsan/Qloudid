namespace Qloudid.Models
{
    public class CheckinAparmentOwnerRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "hotel_property_type")]
        public int HotelPropertyType { get; set; }
    }
}
