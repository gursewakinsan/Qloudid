namespace Qloudid.Models
{
	public class UpdateDependentCheckinIdsRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Certificate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "selected_dependents")]
		public string SelectedDependentIds { get; set; }
	}
}
