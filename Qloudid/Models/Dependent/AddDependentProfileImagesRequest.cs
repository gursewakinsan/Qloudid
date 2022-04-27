namespace Qloudid.Models
{
	public class AddDependentProfileImagesRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ImageData")]
		public string ImageData { get; set; }
	}
}
