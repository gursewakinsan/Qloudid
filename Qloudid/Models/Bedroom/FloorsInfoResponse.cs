namespace Qloudid.Models
{
    public class FloorsInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floor_name")]
        public string FloorName { get; set; }
    }
}
