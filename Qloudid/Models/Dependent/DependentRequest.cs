namespace Qloudid.Models
{
	public class DependentRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
