namespace Qloudid.Models
{
	public class AdultsCheckedInListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "precheck")]
		public bool PreCheck { get; set; } = true;
	}
}
