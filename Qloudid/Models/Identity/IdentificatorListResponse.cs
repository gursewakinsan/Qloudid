namespace Qloudid.Models
{
    public class IdentificatorListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id_name")]
        public string IdName { get; set; }

        public bool IsChecked { get; set; } = false;

        /*[Newtonsoft.Json.JsonProperty(PropertyName = "identification_type")]
        public int Identification_type { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public int user_id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string identity_number { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string issue_month { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public int issue_year { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string expiry_month { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public int expiry_year { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string created_on { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string front_image_path { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string back_image_path { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string issue_date { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public int is_completed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public int is_complete { get; set; }
        */
    }
}
