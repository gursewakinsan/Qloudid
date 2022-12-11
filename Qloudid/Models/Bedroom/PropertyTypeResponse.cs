namespace Qloudid.Models
{
    public class PropertyTypeResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_type")]
        public string PropertyType { get; set; }
    }
}
