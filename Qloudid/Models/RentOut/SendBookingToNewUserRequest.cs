namespace Qloudid.Models
{
    public class SendBookingToNewUserRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_date")]
        public string CheckInDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkout_date")]
        public string CheckOutDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_user_id")]
        public int GuestUserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_paid")]
        public int IsPaid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "room_price")]
        public int RoomPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_adults")]
        public int GuestAdults { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
        public int GuestChildren { get; set; }
    }
}