namespace Qloudid.Models
{
    public class UserApartmentTicketListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_status")]
        public int TicketStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "problem_description")]
        public string ProblemDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_type")]
        public int TicketType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_title")]
        public string TicketTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_subtitle")]
        public string TicketSubtitle { get; set; }

        public bool IconRed { get; set; }

        public bool IconYellow { get; set; }

        public bool IconBlue { get; set; }

        public bool IconGreen { get; set; }

        public bool IsAction { get; set; }
    }
}