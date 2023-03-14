namespace Qloudid.Models
{
    public class ReservationHistoryListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_date")]
        public string CheckinDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checked_in")]
        public int CheckedIn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "precheckin_status")]
        public int PreCheckInStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_booking_date")]
        public string CheckInBookingDate { get; set; }

        public bool IconRed { get; set; }

        public bool IconYellow { get; set; }

        public bool IconBlue { get; set; }

        public bool IconGreen { get; set; }

        public bool IsAction { get; set; }
    }
}
