namespace Qloudid.Models
{
    public class AddIdentificatorImagesRegisteredUserRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "imageId")]
        public int ImageId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_user_Id")]
        public int GuestUserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ImageData")]
        public string ImageData { get; set; }
    }
}