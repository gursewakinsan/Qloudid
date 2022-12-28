namespace Qloudid.Models
{
    public class GetBlockedDatesResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "blocked_date")]
        public string BlockedDate { get; set; }

        /*[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int user_address_id { get; set; }*/
    }
}
