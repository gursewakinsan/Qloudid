namespace Qloudid.Models
{
	public class InterAppRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "password")]
		public string Password { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }
	}
}
