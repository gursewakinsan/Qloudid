namespace Qloudid.Models
{
    public class UserApartmentTicketListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
