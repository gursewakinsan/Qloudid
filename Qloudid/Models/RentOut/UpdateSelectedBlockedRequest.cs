namespace Qloudid.Models
{
    public class UpdateSelectedBlockedRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "selected_dates")]
        public string SelectedDates { get; set; }
    }
}
