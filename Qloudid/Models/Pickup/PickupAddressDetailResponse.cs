namespace Qloudid.Models
{
	public class PickupAddressDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
		public string PortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
		public string Zipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "pickup_address_name")]
		public string PickupAddressName { get; set; }
	}
}
