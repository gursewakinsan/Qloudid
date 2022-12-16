namespace Qloudid.Models
{
    public class UpdateSecurityRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "update_info")]
        public int UpdateInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "security_fee")]
        public int SecurityFee { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}