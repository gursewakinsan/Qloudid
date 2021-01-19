namespace Qloudid.Models
{
	public class AddDeliveryAddressRequest
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string DeliveryAddress { get; set; }
		public string DeliveryPortNumber { get; set; }
		public string DeliveryZipCode { get; set; }
		public string DeliveryCity { get; set; }
		public string InvoiceAddress { get; set; }
		public string InvoicePortNumber { get; set; }
		public string InvoiceZipCode { get; set; }
		public string InvoiceCity { get; set; }
		public string EntryCode { get; set; }
		public bool IsNameSame { get; set; }
		public bool IsInvoiceAddressSame { get; set; }
	}
}
