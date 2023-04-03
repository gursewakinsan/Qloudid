namespace Qloudid.Models
{
    public class UserAddressBookContactsResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_first_name")]
        public string ContactFirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_last_name")]
        public string ContactLastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_relation")]
        public string ContactRelation { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_image")]
        public string ContactImage { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserImage")]
        public string UserImage { get; set; }

        public bool IsUser { get; set; } = false;
    }
}
