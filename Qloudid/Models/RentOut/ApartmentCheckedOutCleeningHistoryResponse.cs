namespace Qloudid.Models
{
    public class ApartmentCheckedOutCleeningHistoryResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "actual_checkout_date")]
        public string ActualCheckoutDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_cleaned")]
        public int IsCleaned { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_rentable")]
        public int IsRentable { get; set; }

        public bool IconRed { get; set; }

        public bool IconYellow { get; set; }

        public bool IconBlue { get; set; }

        public bool IconGreen { get; set; }

        public bool IsAction { get; set; }
    }
}
/*
  public int is_rentable { get; set; }
        public int is_cleaned { get; set; }
        public string actual_checkout_date { get; set; }
        public int guest_adult { get; set; }
        public int guest_children { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string checkin_date { get; set; }
        public string checkout_date { get; set; }
        public string checkin_booking_date { get; set; }
        public string checkout_booking_date { get; set; }
        public int checked_in { get; set; }
        public string enc { get; set; }
        public string duration { get; set; }
        public string check_in_date { get; set; }
        public string checked_out_date { get; set; }
        public string status { get; set; }
        public string guest { get; set; }
 */