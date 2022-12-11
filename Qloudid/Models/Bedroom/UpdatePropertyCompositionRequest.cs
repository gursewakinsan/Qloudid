namespace Qloudid.Models
{
    public class UpdatePropertyCompositionRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "property_type")]
        public int PropertyType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floors_available")]
        public int FloorsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_floor")]
        public int ApartmentFloor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "entrance_floor")]
        public int EntranceFloor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "private_entrance")]
        public int PrivateEntrance { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "elevator")]
        public int Elevator { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_layout")]
        public int PropertyLayout { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}