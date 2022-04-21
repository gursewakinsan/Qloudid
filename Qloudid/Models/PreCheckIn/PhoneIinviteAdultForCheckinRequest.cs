namespace Qloudid.Models
{
	public class PhoneIinviteAdultForCheckinRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
		public int CountryId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
		public string PhoneNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "precheck")]
		public bool PreCheck { get; set; } = true;
	}
}
