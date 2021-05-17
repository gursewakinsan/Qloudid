namespace Qloudid.Models
{
	public class AddIdentificatorImagesRequest
	{
		public int UserId { get; set; }
		public int imageId { get; set; }
		//public string certi { get; set; }
		public int IdentificatorId { get; set; }
		public string ImageData { get; set; }
	}
}