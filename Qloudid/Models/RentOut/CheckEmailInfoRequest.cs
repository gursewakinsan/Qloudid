namespace Qloudid.Models
{
    public class CheckEmailInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
