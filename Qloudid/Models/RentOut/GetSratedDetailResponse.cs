using System.Collections.ObjectModel;

namespace Qloudid.Models
{
    public class GetSratedDetailResponse: BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_apartment_get_started_id")]
        public int UserApartmentGetStartedId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_updated")]
        public bool IsUpdated { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "get_started_title")]
        public string GetStartedTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
        private bool isAvailable;
        public bool IsAvailable
        {
            get => isAvailable;
            set
            {
                isAvailable = value;
                OnPropertyChanged("IsAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "getstarted_code")]
        private string getStartedCode;
        public string GetStartedCode
        {
            get => getStartedCode;
            set
            {
                getStartedCode = value;
                OnPropertyChanged("GetStartedCode");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "getstarted_password")]
        private string getStartedPassword;
        public string GetStartedPassword
        {
            get => getStartedPassword;
            set
            {
                getStartedPassword = value;
                OnPropertyChanged("GetStartedPassword");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "get_started_description")]
        private string getStartedDescription;
        public string GetStartedDescription
        {
            get => getStartedDescription;
            set
            {
                getStartedDescription = value;
                OnPropertyChanged("GetStartedDescription");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "yes_no_required")]
        public bool YesNoRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "code_required")]
        public bool IsCodeRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        private ObservableCollection<StartedImages> images;
        public ObservableCollection<StartedImages> Images
        {
            get => images;
            set
            {
                images = value;
                OnPropertyChanged("Images");
            }
        }
    }

    public class StartedImages : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

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
