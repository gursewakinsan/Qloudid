namespace Qloudid.Models
{
	public class VerifyRestoreOtpPinResponse
	{
		public int country_code { get; set; }
		public int result { get; set; }
		public string phone_number { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
	}
}
