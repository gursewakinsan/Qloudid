namespace Qloudid.Models
{
	public class DependentsCheckedInListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "precheck")]
		public bool PreCheck { get; set; } = true;
	}
}
