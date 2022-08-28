namespace Qloudid.Models
{
    public class UpdateCountryRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "update_info")]
        public int UpdateInfo { get; set; }
    }
}
