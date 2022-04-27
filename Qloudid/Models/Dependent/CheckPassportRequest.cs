namespace Qloudid.Models
{
	public class CheckPassportRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "PassportNumber")]
		public string PassportNumber { get; set; }
	}
}
