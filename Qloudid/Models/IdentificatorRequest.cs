namespace Qloudid.Models
{
	public class IdentificatorRequest
	{
		public int UserId { get; set; }
		public int IdentificatorId { get; set; }
		public string IdentificatorText { get; set; }
		public int CountryId { get; set; }
		public int IssueMonth { get; set; }
		public int IssueYear { get; set; }
		public int ExpiryMonth { get; set; }
		public int ExpiryYear { get; set; }
	}
}
