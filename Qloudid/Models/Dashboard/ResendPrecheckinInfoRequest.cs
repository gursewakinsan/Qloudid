namespace Qloudid.Models
{
    public class ResendPrecheckinInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "check_id")]
        public int CheckId { get; set; }
    }
}
