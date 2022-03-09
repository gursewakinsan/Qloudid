namespace Qloudid.Models
{
	public class VerifyDependent
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "verification_info")]
		public int VerificationInfo { get; set; }
	}
}
