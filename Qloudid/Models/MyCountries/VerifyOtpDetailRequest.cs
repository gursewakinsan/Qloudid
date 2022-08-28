namespace Qloudid.Models
{
    public class VerifyOtpDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "otp")]
        public string Otp { get; set; }
    }
}