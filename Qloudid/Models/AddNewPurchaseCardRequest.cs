namespace Qloudid.Models
{
	public class AddNewPurchaseCardRequest
	{
		public int UserId { get; set; }
		public string CardNumber { get; set; }
		public string CardHolderName { get; set; }
		public string ExpirationMonth { get; set; }
		public string ExpirationYear { get; set; }
		public string Cvv { get; set; }
		public string certificate_key { get; set; }
	}
}
