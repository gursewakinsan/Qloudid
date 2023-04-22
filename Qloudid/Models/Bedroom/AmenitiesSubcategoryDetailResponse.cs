using System.Collections.Generic;

namespace Qloudid.Models
{
    public class AmenitiesSubcategoryDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_info")]
        public List<SubcategoryInfo> SubCategoryInfo { get; set; }
    }

    public class SubcategoryInfo
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_name")]
        public string SubCategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
        public bool IsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "who_will_fix_the_problem")]
        public int WhoWillFixTheProblem { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "advance_values")]
        public int AdvanceValues { get; set; }
    }
}

