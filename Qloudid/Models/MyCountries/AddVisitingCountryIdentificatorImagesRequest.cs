namespace Qloudid.Models
{
    public class AddVisitingCountryIdentificatorImagesRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "ImageData")]
        public string ImageData { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "imageId")]
        public int ImageId { get; set; }
    }
}
