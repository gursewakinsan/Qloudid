namespace Qloudid.Models
{
	public class AdultsCheckedInListResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_confirmed")]
		public bool IsConfirmed { get; set; }

		public Xamarin.Forms.Color FrameBorderColor { get; set; }


		/*[Newtonsoft.Json.JsonProperty(PropertyName = "invitation_type")]
		public int InvitationType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_code")]
		public int CountryCode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
		public string PhoneNumber { get; set; }*/
	}
}
