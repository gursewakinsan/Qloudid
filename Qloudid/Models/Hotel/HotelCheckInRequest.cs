namespace Qloudid.Models
{
	public class HotelCheckInRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }

	}
}
