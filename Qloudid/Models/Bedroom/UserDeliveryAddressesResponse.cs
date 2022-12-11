namespace Qloudid.Models
{
    public class UserDeliveryAddressesResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
        public string ZipCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
        public string NameOnHouse { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bedroom_updated")]
        public bool BedroomUpdated { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_updated")]
        public bool BathroomUpdated { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
        public string PropertyNickName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_address")]
        public int UserAddress { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "heading_address")]
        public string HeadingAddress { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subheading_address")]
        public string SubheadingAddress { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "other_room_updated")]
        public bool IsOtherRoomUpdated { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_composition_updated")]
        public bool IsPropertyCompositionUpdated { get; set; }

        public string DisplayName => string.IsNullOrWhiteSpace(PropertyNickName) ? NameOnHouse : PropertyNickName;
        public bool IsBedroomBathroomUpdated => (BedroomUpdated && BathroomUpdated) ? true : false;
    }
}
