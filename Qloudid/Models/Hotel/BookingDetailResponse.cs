namespace Qloudid.Models
{
	public class BookingDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "longitude")]
		public string Longitude { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "latitude")]
		public string Latitude { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_name")]
		public string HotelName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_address")]
		public string VisitingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_type_name")]
		public string RoomTypeName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_price")]
		public int RoomPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_type")]
		public string RoomType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "price")]
		public int Price { get; set; }
	}
}
