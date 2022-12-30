using System.Collections.Generic;

namespace Qloudid.Models
{
    public class GetSratedDetailResponse
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
        public bool IsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "getstarted_code")]
        public string GetStartedCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "getstarted_password")]
        public string GetStartedPassword { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "get_started_description")]
        public string GetStartedDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "yes_no_required")]
        public bool YesNoRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "code_required")]
        public bool CodeRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<SratedImages> Images { get; set; }
    }

    public class SratedImages : BaseModel
    {
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
