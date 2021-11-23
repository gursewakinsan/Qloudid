namespace Qloudid.Models
{
	public class SubmitWaitListResturantDetail
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "qid")]
		public int Qid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_person")]
		public int TotalPerson { get; set; }
	}
}
