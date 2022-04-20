namespace Qloudid.Models
{
	public class GetPreCheckinStatusRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int userId { get; set; }
	}
}
