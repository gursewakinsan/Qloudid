namespace Qloudid.Models
{
	public class DependentsListForCheckInRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }
	}
}
