namespace Qloudid.Models
{
	public class InformToEmployeeRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_company")]
		public int IsCompany { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visitor_profile_id")]
		public int VisitorProfileId { get; set; }
	}
}
