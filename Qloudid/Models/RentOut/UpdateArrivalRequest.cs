namespace Qloudid.Models
{
    public class UpdateArrivalRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "arrival_time")]
        public string ArrivalTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "departure_time")]
        public string DepartureTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
