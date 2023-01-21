namespace Qloudid.Models
{
    public class AddIdentificatorRegisteredUserRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "IdentificatorText")]
        public string IdentificatorText { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "CountryId")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "IssueDate")]
        public string IssueDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ExpiryDate")]
        public string ExpiryDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guest_user_Id")]
        public int GuestUserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "IdentificatorId")]
        public int IdentificatorId { get; set; }
    }
}