namespace Qloudid.Models
{
    public class BedTypeDetail
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_type")]
        public string BedType { get; set; }
    }
}
