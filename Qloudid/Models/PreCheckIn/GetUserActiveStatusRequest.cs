namespace Qloudid.Models
{
	public class GetUserActiveStatusRequest
	{

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
