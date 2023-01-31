namespace Qloudid.Models
{
	public class User : BaseModel
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public int user_id { get; set; }
		public int result { get; set; }
		public string certificate_key { get; set; }
		public string UserImage { get; set; }
		public string DisplayUserName => $"{first_name} {last_name}";

		private bool passportCount;
		public bool PassportCount
		{
			get => passportCount;
			set
			{
				passportCount = value;
				OnPropertyChanged("PassportCount");
			}
		}

		private bool cardCount;
		public bool CardCount
		{
			get => cardCount;
			set
			{
				cardCount = value;
				OnPropertyChanged("CardCount");
			}
		}
	}
}