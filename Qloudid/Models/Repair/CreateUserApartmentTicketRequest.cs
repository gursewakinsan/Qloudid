namespace Qloudid.Models
{
    public class CreateUserApartmentTicketRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_id")]
        public int TicketId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subticket_id")]
        public int SubticketId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "problem_description")]
        public string ProblemDescription { get; set; }
    }
}