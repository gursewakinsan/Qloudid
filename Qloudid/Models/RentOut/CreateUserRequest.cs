namespace Qloudid.Models
{
    public class CreateUserRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pcountry")]
        public int PCountry { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "p_number")]
        public string PNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id_number")]
        public string IdNumber { get; set; }
    }
}
