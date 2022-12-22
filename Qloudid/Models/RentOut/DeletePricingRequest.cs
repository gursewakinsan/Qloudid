namespace Qloudid.Models
{
    public class DeletePricingRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pid")]
        public int Pid { get; set; }
    }
}
