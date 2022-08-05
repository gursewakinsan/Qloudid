namespace Qloudid.Models
{
    public class UpdateBedTypeInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_id")]
        public int BedId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_info")]
        public string BedInfo { get; set; }
    }
}
