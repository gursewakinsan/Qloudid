namespace Qloudid.Models
{
    public class UpdateBathroomRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "update_type")]
        public string UpdateType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "aid")]
        public int AId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_id")]
        public int BathroomId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bath")]
        public string Bath { get; set; }
    }
}