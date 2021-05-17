namespace Qloudid.Models
{
	public class UpdateCheckRequiredRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "check")]
		public int Check { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }
	}
}
