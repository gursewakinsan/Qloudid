namespace Qloudid.Models
{
	public class CheckInDependentRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "ip")]
		public string Ip { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }
	}
}
