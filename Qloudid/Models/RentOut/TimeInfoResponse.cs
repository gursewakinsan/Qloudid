namespace Qloudid.Models
{
    public class TimeInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
    }
}
