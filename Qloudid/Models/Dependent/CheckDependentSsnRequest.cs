namespace Qloudid.Models
{
	public class CheckDependentSsnRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "SocialSecurityNumber")]
		public string SocialSecurityNumber { get; set; }
	}
}
