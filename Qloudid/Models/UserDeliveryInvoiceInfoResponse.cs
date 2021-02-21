namespace Qloudid.Models
{
	public class UserDeliveryInvoiceInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address")]
		public string InvoiceAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_zipcode")]
		public string InvoiceZipCode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_city")]
		public string InvoiceCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_port")]
		public string InvoicePort { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address_required")]
		public bool InvoiceAddressRequired { get; set; }
	}
}
