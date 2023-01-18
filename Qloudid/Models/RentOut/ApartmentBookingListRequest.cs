namespace Qloudid.Models
{
    public class ApartmentBookingListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
