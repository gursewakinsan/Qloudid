namespace Qloudid.Models
{
	public class EmployerResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "invited_emp")]
		public int InvitedEmp { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "status")]
		public bool Status { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_date")]
		public string CreatedDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
		public string CompanyName { get; set; }
	}
}
