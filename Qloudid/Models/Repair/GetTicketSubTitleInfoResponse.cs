namespace Qloudid.Models
{
    public class GetTicketSubTitleInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_subtitle")]
        public string TicketSubtitle { get; set; }

       // public int ticket_id { get; set; }
    }
}
