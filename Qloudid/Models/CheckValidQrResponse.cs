namespace Qloudid.Models
{
	public class CheckValidQrResponse : BaseModel
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public int id { get; set; }
		public string image { get; set; }
		public int result { get; set; }
		public int identificator { get; set; }
		public int country_code { get; set; }
        public bool passport_count { get; set; }
        public bool card_count { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "precheck_in_count")]
		public bool PreCheckInCount { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_started")]
		public bool PropertyStarted { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_of_residence")]
		public int CountryOfResidence { get; set; }
	}
}
