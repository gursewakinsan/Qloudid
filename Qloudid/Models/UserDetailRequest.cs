namespace Qloudid.Models
{
    public class UserDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
        public string Certificate { get; set; }
    }
}
