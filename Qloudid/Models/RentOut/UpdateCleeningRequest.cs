namespace Qloudid.Models
{
    public class UpdateCleeningRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "update_info")]
        public int UpdateInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cleening_fee")]
        public int CleeningFee { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
