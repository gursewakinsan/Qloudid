namespace Qloudid.Models
{
    public class ChangeTextOrAvailabilityRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
