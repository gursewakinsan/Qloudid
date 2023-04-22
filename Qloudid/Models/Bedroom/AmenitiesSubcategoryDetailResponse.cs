using System.Collections.Generic;

namespace Qloudid.Models
{
    public class AmenitiesSubcategoryDetailResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "advance_values")]
        public int AdvanceValues { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "count")]
        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_info")]
        private List<SubcategoryInfo> subCategoryInfo;
        public List<SubcategoryInfo> SubCategoryInfo
        {
            get => subCategoryInfo;
            set
            {
                subCategoryInfo = value;
                OnPropertyChanged("SubCategoryInfo");
            }
        }

        private bool isOpen = false;
        public bool IsOpen
        { 
            get=> isOpen;
            set
            {
                isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }
    }

    public class SubcategoryInfo : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_name")]
        public string SubCategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

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

        [Newtonsoft.Json.JsonProperty(PropertyName = "who_will_fix_the_problem")]
        public int WhoWillFixTheProblem { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "advance_values")]
        public int AdvanceValues { get; set; }
    }
}

