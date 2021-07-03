namespace Qloudid.Models
{
	public class PickupAddressDetailRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public string CompanyId { get; set; }
	}
}
