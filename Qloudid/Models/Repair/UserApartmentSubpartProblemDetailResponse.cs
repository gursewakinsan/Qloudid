namespace Qloudid.Models
{
    public class UserApartmentSubpartProblemDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "subpart_info")]
        public int SubpartInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subpart_title")]
        public string SubpartTitle { get; set; }
    }
}
