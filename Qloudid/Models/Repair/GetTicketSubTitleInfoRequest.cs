﻿namespace Qloudid.Models
{
    public class GetTicketSubTitleInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_id")]
        public int TicketId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
