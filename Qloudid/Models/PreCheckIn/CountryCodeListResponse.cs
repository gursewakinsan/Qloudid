namespace Qloudid.Models
{
	public class CountryCodeListResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_code")]
		public string CountryCode { get; set; }
	}
}
