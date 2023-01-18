namespace Qloudid.Models
{
    public class ApartmentBookingListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_date")]
        public string CheckinDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
        public int GuestAdult { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
        public int GuestChildren { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "circle_count")]
        public int CircleCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guests")]
        public string Guests { get; set; }
    }
}
