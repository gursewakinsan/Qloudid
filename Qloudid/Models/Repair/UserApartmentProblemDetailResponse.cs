namespace Qloudid.Models
{
    public class UserApartmentProblemDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_id")]
        public int TicketId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_title")]
        public string TicketTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subpart_info")]
        public int SubpartInfo { get; set; }

        public string TicketIcon { get; set; }
        public string TicketIconColor { get; set; }

        public bool IsRightLine { get; set; } = false;
        public bool IsBottomLine { get; set; } = false;
    }
}
