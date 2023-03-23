namespace Qloudid.Models
{
    public class UpdateApartmentKeyInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "key_available")]
        public bool KeyAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "key_description")]
        public string KeyDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "total_keys")]
        public int TotalKeys { get; set; }
    }
}