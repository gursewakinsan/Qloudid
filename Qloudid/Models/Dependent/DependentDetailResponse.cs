using Xamarin.Forms;

namespace Qloudid.Models
{
	public class DependentDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ssn")]
		public string Ssn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_by")]
		public int CreatedBy { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_approved")]
		public int IsApproved { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dependent_type")]
		public int DependentType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
		public int CountryId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "blood_group")]
		public string BloodGroup { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "allergic")]
		public string Allergic { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "p_country")]
		public int PCountry { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_number")]
		public string PassportNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "issue_month")]
		public string IssueMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "issue_year")]
		public string IssueYear { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "expiry_month")]
		public string ExpiryMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "expiry_year")]
		public string ExpiryYear { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "front_image_path")]
		public string FrontImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "back_image_path")]
		public string BackImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_completed")]
		public int IsCompleted { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "issue_date")]
		public string IssueDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "expiry_date")]
		public string ExpiryDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_ssn_available")] 
		public bool IsSsnAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_address_same")]
		public bool IsAddressSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "child_address")]
		public string ChildAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "child_city")]
		public string ChildCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "child_zip")]
		public string ChildZip { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "child_port_number")]
		public string ChildPortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_passport_updated")]
		public bool IsPassportUpdated { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "birth_day")]
		public int BirthDay { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "birth_month")]
		public int BirthMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "birth_year")]
		public int BirthYear { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_name")]
		public string CountryName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dob")]
		public string Dob { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "age")]
		public int Age { get; set; }

		public Color PassportBg => IsPassportUpdated ? Color.FromHex("#0F9D58") : Color.FromHex("#242A37");
	}
}
