namespace Qloudid.Models
{
    public class UpdateTextOrAvailabilityRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "propertyNickname")]
        public string PropertyNickName { get; set; }
    }
}
