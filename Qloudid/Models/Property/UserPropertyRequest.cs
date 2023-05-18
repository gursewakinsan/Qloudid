namespace Qloudid.Models
{
    public class UserPropertyRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
    }
}