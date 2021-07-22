using System;

namespace Qloudid.Models
{
	public class AddDependentRequest
	{
		public int UserId { get; set; }
		public int DependentType { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string SocialSecurityNumber { get; set; }
		public string PassportNumber { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
