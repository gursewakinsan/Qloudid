namespace Qloudid.Models
{
	public class DependentsListForCheckinDstrictRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "precheck")]
		public bool PreCheck { get; set; } = true;
	}
}
