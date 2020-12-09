namespace Qloudid.Models
{
	public class IdentificatorRequest
	{
		public int UserId { get; set; }
		public int IdentificatorId { get; set; }
		public string IdentificatorText { get; set; }
		public int CountryId { get; set; }
		public string IssueDate { get; set; }
		public string ExpiryDate { get; set; }
	}
}
