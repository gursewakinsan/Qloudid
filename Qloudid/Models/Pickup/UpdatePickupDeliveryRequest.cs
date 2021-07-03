namespace Qloudid.Models
{
	public class UpdatePickupDeliveryRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "delivery_type")]
		public int DeliveryType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }
	}
}
