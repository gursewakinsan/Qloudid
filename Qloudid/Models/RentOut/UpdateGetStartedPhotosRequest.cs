namespace Qloudid.Models
{
    public class UpdateGetStartedPhotosRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "gid")]
        public int GId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "update_info")]
        public string UpdateInfo { get; set; }
    }
}
