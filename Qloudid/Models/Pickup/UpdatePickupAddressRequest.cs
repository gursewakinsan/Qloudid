namespace Qloudid.Models
{
	public class UpdatePickupAddressRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "pickup_address_id")]
		public int PickupAddressId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }
	}
}
