namespace Qloudid.Models
{
	public class GetPreCheckinStatusResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "result")]
		public int Result { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_dates")]
		public string BookingDates { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_name")]
		public string HotelName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guests")]
		public string Guests { get; set; }
	}
}