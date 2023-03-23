namespace Qloudid.Models
{
    public class DisplayKeyPhotosResponse
    {
		[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_photo_path")]
		public string ApartmentPhotoPath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "sorting_number")]
		public int SortingNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }
	}
}
