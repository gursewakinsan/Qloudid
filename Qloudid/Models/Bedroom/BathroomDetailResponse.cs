using Xamarin.Forms;

namespace Qloudid.Models
{
    public class BathroomDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_count")]
        public int BathroomCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_address_id")]
        public int UserAddressId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "toilet_and_sink")]
        public bool ToiletAndSink { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bath")]
        public bool Bath { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "shower")]
        public bool Shower { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "standalone_shower")]
        public bool StandaloneShower { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "over_bath_shower")]
        public bool OverBathShower { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_private")]
        public bool IsPrivate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_wheelchair_accessible")]
        public bool IsWheelchairAccessible { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_ensuit")]
        public bool IsEnsuit { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }

        public Color ToiletAndSinkBg => ToiletAndSink ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        public Color ShowerBg => Shower ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        public Color BathBg => Bath ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        public Color PrivateBg => IsPrivate ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        public Color EnsuitBg => IsEnsuit ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        public Color WheelchairAccessibleBg => IsWheelchairAccessible ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
    }
}
