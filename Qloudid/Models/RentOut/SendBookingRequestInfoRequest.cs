﻿namespace Qloudid.Models
{
    public class SendBookingRequestInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_date")]
        public string CheckinDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkout_date")]
        public string CheckoutDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "hotel_property_type")]
        public int HotelPropertyType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_user_id")]
        public int GuestUserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "room_price")]
        public string RoomPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_adults")]
        public string GuestAdults { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_paid")]
        public int IsPaid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
        public string GuestChildren { get; set; }
    }
}