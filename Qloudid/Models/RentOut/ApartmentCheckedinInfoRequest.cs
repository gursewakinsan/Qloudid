namespace Qloudid.Models
{
    public class ApartmentCheckedinInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
