namespace Qloudid.Models
{
	public class VerifyEmailOtpPinRequest
	{
		public int UserId { get; set; }
		public string OtpPin { get; set; }
	}
}
