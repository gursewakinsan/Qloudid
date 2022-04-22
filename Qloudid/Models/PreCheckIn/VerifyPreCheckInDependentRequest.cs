namespace Qloudid.Models
{
	public class VerifyPreCheckInDependentRequest
	{
		public VerifyDependentType SelectedVerifyDependentType { get; set; }
		public string PhoneNumber { get; set; }
		public int CountryId { get; set; }
		public string EmailAddress { get; set; }
		public int AdultId { get; set; }
	}
	public enum VerifyDependentType
	{
		ByPhone = 0,
		ByEmail = 1,
		OnlyAdult = 2
	}
}
