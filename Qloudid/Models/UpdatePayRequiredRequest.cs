namespace Qloudid.Models
{
	public class UpdatePayRequiredRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "pay")]
		public int Pay { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }
	}
}
