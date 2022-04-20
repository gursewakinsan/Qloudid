namespace Qloudid.Models
{
	public class GetUserActiveStatusResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "cards")]
		public int Cards { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public int Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "passport")]
		public int Passport { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_id")]
		public int PassportId { get; set; }
	}
}
