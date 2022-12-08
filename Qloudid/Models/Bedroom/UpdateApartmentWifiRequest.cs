namespace Qloudid.Models
{
    public class UpdateApartmentWifiRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "wifi_available")]
        public int WifiAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wifi_username")]
        public string WifiUsername { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wifi_password")]
        public string WifiPassword { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
