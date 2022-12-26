namespace Qloudid.Models
{
    public class DisplayPhotosResponse : BaseModel
    {
		[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_photo_path")]
		public string ApartmentPhotoPath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "sorting_number")]
		public int SortingNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		private bool isAddNewPhoto;
		public bool IsAddNewPhoto
		{
			get => isAddNewPhoto;
			set
			{
				isAddNewPhoto = value;
				OnPropertyChanged("IsAddNewPhoto");
			}
		}
	}
}
