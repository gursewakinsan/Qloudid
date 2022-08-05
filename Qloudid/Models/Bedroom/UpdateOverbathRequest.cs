namespace Qloudid.Models
{
    public class UpdateOverbathRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "standalone")]
        public int StandAlone { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "overbath")]
        public int OverBath { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_id")]
        public int BathroomId { get; set; }
    }
}