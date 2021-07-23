namespace Qloudid.Models
{
	public class AddDependentImagesRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "ImageData")]
		public string ImageData { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "imageId")]
		public int ImageId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
		public int UserId { get; set; }
	}
}
