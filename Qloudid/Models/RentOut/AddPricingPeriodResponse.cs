namespace Qloudid.Models
{
    public class AddPricingPeriodResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "startdate")]
        public string StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enddate")]
        public string EndDate { get; set; }
    }
}
