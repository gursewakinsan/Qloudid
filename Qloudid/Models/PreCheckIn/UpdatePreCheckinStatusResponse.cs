namespace Qloudid.Models
{
	public class UpdatePreCheckinStatusResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
		public int GuestAdult { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
		public int GuestChildren { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult_left")]
		public int GuestAdultLeft { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children_left")]
		public int GuestChildrenLeft { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_left")]
		public int TotalLeft { get; set; }
	}
}
