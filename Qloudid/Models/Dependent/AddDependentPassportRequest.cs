namespace Qloudid.Models
{
	public class AddDependentPassportRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "PassportNumber")]
		public string PassportNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "IssueMonth")]
		public int IssueMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "IssueYear")]
		public int IssueYear { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ExpiryMonth")]
		public int ExpiryMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ExpiryYear")]
		public int ExpiryYear { get; set; }
	}
}
