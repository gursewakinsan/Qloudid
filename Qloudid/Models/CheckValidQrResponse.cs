namespace Qloudid.Models
{
	public class CheckValidQrResponse
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public int id { get; set; }
		public string image { get; set; }
		public int result { get; set; }
		public int identificator { get; set; }
		public int country_code { get; set; }
	}
}
