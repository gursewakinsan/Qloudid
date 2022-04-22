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

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int Checkid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
		public int GuestAdult { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
		public int GuestChildren { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult_left")]
		public int GuestAdultLeft { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children_left")]
		public int GuestChildrenLeft { get; set; }
	}
}