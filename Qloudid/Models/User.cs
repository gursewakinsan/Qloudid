namespace Qloudid.Models
{
	public class User
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public int user_id { get; set; }
		public int result { get; set; }
		public string DisplayUserName => $"{first_name} {last_name}";
	}
}
