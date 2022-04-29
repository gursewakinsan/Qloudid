namespace Qloudid.Models
{
	public class UpdateDependentRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }
		public int DependentType { get; set; }
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }
		public string SocialSecurityNumber { get; set; }
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_ssn_available")]
		public int IsSsnAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
		public string ZipCode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
		public string PortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_same_address")]
		public int IsSameAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "birth_day")]
		public int BirthDay { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "birth_month")]
		public int BirthMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "birth_year")]
		public int BirthYear { get; set; }
	}
}
