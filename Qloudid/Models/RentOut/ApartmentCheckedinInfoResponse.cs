﻿namespace Qloudid.Models
{
    public class ApartmentCheckedinInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
        public int GuestAdult { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
        public int GuestChildren { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_date")]
        public string CheckinDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkout_date")]
        public string CheckoutDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkin_booking_date")]
        public string CheckinBookingDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkout_booking_date")]
        public string CheckoutBookingDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
        public string Enc { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "check_in_date")]
        public string CheckInDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checked_out_date")]
        public string CheckedOutDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest")]
        public string Guest { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "list_status")]
        public int ListStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subheading")]
        public string Subheading { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checked_in")]
        public int CheckedIn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "got_to_cleaning")]
        public int GotToCleaning { get; set; }

        public bool IconRed { get; set; }

        public bool IconYellow { get; set; }

        public bool IconBlue { get; set; }

        public bool IconGreen { get; set; }

        public bool IsAction { get; set; }
    }
}
