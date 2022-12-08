namespace Qloudid.Models
{
	public class EditAddressResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
		public string Zipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
		public string PortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address")]
		public string InvoiceAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_city")]
		public string InvoiceCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_zipcode")]
		public string InvoiceZipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_port_number")]
		public string InvoicePortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_name_same")]
		public int IsNameSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_invoice_same")]
		public int IsInvoiceSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
		public string NameOnHouse { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_personal_address")]
		public int IsPersonalAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "entry_code")]
		public string EntryCode { get; set; }
		public string CertificateKey { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "delivered_at")]
		public int DeliveredAt { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wi_fi_updated")]
		public bool IsWiFiUpdated { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_available")]
		public bool IsWifiAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_username")]
		public string WifiUsername { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_password")]
		public string WifiPassword { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_floor")]
		public string ApartmentFloor { get; set; }
	}
}
