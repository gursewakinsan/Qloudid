namespace Qloudid.Models
{
    public class GeneratePricingRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "date_picker")]
        public string DatePicker { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "seasonality_template")]
        public int SeasonalityTemplate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "standard_price_per_night")]
        public int StandardPricePerNight { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "t_nights")]
        public int TNights { get; set; }
    }
}
 