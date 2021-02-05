namespace Qloudid.Models
{
	public class InterAppResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "result")]
		public int Result { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "session")]
		public string Session { get; set; }
	}
}
