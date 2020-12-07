namespace Qloudid.Models
{
	public class VerifyRestoreOtpPinRequest
	{
		public int UserId { get; set; }
		public string OtpPin { get; set; }
	}
}
