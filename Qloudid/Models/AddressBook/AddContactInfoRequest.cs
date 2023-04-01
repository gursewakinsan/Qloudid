using System.Collections.Generic;

namespace Qloudid.Models
{
    public class AddContactInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email_type_info")]
        public List<EmailTypeInfo> EmailTypeInfo { get; set; }
    }

    public class EmailTypeInfo
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email_type")]
        public string EmailType { get; set; }
    }
}
