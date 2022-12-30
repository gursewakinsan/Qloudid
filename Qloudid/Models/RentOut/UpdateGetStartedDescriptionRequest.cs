namespace Qloudid.Models
{
    public class UpdateGetStartedDescriptionRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "getstarted_code")]
        public string GetStartedCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "getstarted_password")]
        public string GetStartedPassword { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
        public int IsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "propertyNickname")]
        public string PropertyNickname { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "gid")]
        public int GId { get; set; }
    }
}