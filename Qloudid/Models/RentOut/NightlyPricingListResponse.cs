namespace Qloudid.Models
{
    public class NightlyPricingListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pricing_title")]
        public string PricingTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_deleted")]
        public bool IsDeleted { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pricingDate")]
        public string PricingDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum_price")]
        public int MinimumPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "maximum_price")]
        public int MaximumPrice { get; set; }
    }
}
