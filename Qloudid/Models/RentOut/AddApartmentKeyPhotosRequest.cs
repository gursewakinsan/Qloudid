namespace Qloudid.Models
{
    public class AddApartmentKeyPhotosRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "update_info")]
        public string UpdateInfo { get; set; }
    }
}