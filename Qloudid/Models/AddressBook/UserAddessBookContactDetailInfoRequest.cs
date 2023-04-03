namespace Qloudid.Models
{
    public class UserAddessBookContactDetailInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_id")]
        public int ContactId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_user")]
        public bool IsUser { get; set; }
    }
}
