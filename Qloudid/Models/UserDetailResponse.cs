namespace Qloudid.Models
{
    public class UserDetailResponse
    {
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public int user_id { get; set; }
		public int result { get; set; }
		public string certificate_key { get; set; }
		public string UserImage { get; set; }
	}
}
