namespace Qloudid.Models
{
	public class InvoiceAddressResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "is_user")]
		public bool IsUser { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "index_id")]
		public string IndexId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
		public string NameOnHouse { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address")]
		public string InvoiceAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_city")]
		public string InvoiceCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_zip")]
		public string InvoiceZip { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_country")]
		public string InvoiceCountry { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_port_number")]
		public string InvoicePortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }
	}
}
