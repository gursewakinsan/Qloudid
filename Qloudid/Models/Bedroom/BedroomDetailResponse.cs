using System.Collections.Generic;

namespace Qloudid.Models
{
    public class BedroomDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_address_id")]
        public int UserAddressId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bedroom_count")]
        public int BedroomCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_type")]
        public List<BedType> BedTypeList { get; set; }
    }

    public class BedType
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bedroom_id")]
        public int BedroomId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_info")]
        public string BedInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bedtype")]
        public List<Bedtype> BedTypeList { get; set; }
        public Bedtype SelectedBedType { get; set; }
    }

    public class Bedtype
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_type")]
        public string BedType { get; set; }
    }
}
