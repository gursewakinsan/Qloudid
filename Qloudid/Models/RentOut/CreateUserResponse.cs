namespace Qloudid.Models
{
    public class CreateUserResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
