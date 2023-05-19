namespace Qloudid.Models
{
    public class SendLandloardRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "b_id")]
        public int BId { get; set; }
    }
}