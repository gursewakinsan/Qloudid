namespace Qloudid.Models
{
	public class PayCartItemRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_type")]
		public int ServiceType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "qloud_id_pay")]
		public int QloudIdPay { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_company")]
		public int IsCompany { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address_id")]
		public int InvoiceAddressId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "card_id")]
		public int CardId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }
	}
}
