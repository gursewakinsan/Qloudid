namespace Qloudid.Models
{
    public class UpdatePricingRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "pid")]
        public int Pid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "startdate")]
        public string StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enddate")]
        public string EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "monday_open")]
        public int MondayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tuesday_open")]
        public int TuesdayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wednesday_open")]
        public int WednesdayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "thursday_open")]
        public int ThursdayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "friday_open")]
        public int FridayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "saturday_open")]
        public int SaturdayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "sunday_open")]
        public int SundayOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "monday_price")]
        public int MondayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tuesday_price")]
        public int TuesdayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wednesday_price")]
        public int WednesdayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "thursday_price")]
        public int ThursdayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "friday_price")]
        public int FridayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "saturday_price")]
        public int SaturdayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "sunday_price")]
        public int SundayPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "maximum_price")]
        public int MaximumPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum_price")]
        public int MinimumPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "discount_for_seven")]
        public int DiscountForSeven { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "shortest_duration")]
        public int ShortestDuration { get; set; }
    }
}
