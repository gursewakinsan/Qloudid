namespace Qloudid.Models
{
    public class HomeRepairCategoryInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_title")]
        public string TicketTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
        public string Enc { get; set; }
    }
}
