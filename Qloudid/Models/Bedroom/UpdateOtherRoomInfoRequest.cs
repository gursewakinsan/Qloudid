namespace Qloudid.Models
{
    public class UpdateOtherRoomInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "updateInfo")]
        public int UpdateInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
