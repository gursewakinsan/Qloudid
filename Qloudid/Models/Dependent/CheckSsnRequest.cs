namespace Qloudid.Models
{
	public class CheckSsnRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "SocialSecurityNumber")]
		public string SocialSecurityNumber { get; set; }
	}
}
