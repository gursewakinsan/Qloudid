namespace Qloudid.Models
{
	public class DeliveryAddressDetailRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_address")]
		public int UserAddress { get; set; }
	}
}
