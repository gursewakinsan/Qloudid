namespace Qloudid.Models
{
	public class AddressesResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_address")]
		public int UserAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "heading_address")]
		public string HeadingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "subheading_address")]
		public string SubheadingAddress { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(HeadingAddress, 0).ToUpper();
	}
}
