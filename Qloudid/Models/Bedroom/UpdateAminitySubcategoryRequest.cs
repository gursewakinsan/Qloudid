namespace Qloudid.Models
{
    public class UpdateAminitySubcategoryRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_amenity_id")]
        public int UserAmenityId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
        public int IsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "who_will_fix_the_problem")]
        public int WhoWillFixTheProblem { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "advance_values")]
        public int AdvanceValues { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "update_type")]
        public int UpdateType { get; set; }
    }
}
