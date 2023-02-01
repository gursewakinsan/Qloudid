namespace Qloudid.Models
{
    public class ApartmentReservationConfermationResponse
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
        public bool PreCheckInStatus { get; set; }

        /*[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int guest_adult { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int guest_children { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int guest_infant { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public string checkin_date { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public string checkout_date { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int room_type_id { get; set; }

       

       
        public string created_on { get; set; }
        public int is_paid { get; set; }
        public int buyer_id { get; set; }
        public int is_buyer_company { get; set; }
        public object card_id { get; set; }
        public object cust_id { get; set; }
        public object transection_id { get; set; }
        public int user_id { get; set; }
        public int room_id { get; set; }
        public string checkin_code { get; set; }
        public int checked_in { get; set; }
        public int hotel_property_type { get; set; }
        public int chekin_type { get; set; }
        public string checkin_booking_date { get; set; }
        public string checkout_booking_date { get; set; }
        public object hotel_id { get; set; }
        public object property_id { get; set; }
        public int key_received { get; set; }
        public object room_cleaning_staff_id { get; set; }
        public int room_cleaning_status { get; set; }
        public object room_cleaning_date { get; set; }
        public int room_cleaning_allocated { get; set; }
        public object checkout_time_info { get; set; }
        public int precheckin_status { get; set; }
        public object delivery_address_id { get; set; }
        public int payment_option { get; set; }
        public string guest_email { get; set; }
        public int reservation_confirmed { get; set; }
        public object company_name { get; set; }
        public object cid_number { get; set; }
        public object d_address { get; set; }
        public object dpo_number { get; set; }
        public object dzip { get; set; }
        public object dcity { get; set; }
        public object name_on_card { get; set; }
        public object card_number { get; set; }
        public object expiry_month { get; set; }
        public object expiry_year { get; set; }
        public object cvv_number { get; set; }
        public string enc { get; set; }
        */
    }
}
