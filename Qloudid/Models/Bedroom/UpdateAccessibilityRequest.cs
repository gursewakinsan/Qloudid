namespace Qloudid.Models
{
    public class UpdateAccessibilityRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "update_type")]
        public int UpdateType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "private_info")]
        public int PrivateInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_id")]
        public int BathroomId { get; set; }
    }
}