namespace Qloudid.Models
{
    public class ApartmentPreCheckinRequiredListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
        public string PropertyNickName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest")]
        public string Guest { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "total_days")]
        public int TotalDays { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "precheckin_status")]
        public int PreCheckInStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
        public int GuestAdult { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
        public int GuestChildren { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
        public string Enc { get; set; }

        public bool IsStartPreCheckIn { get; set; }
    }
}
