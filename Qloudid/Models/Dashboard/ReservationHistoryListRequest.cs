namespace Qloudid.Models
{
    public class ReservationHistoryListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
