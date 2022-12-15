namespace Qloudid.Models
{
    public class UpdateApartmentHouseRulesRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "children_allowed")]
        public int ChildrenAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "infants_allowed")]
        public int InfantsAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "smoking_allowed")]
        public int SmokingAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "events_allowed")]
        public int EventsAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pets_allowed")]
        public int PetsAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs")]
        public int QuiteHrs { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri")]
        public int QuiteHrsMonFri { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun")]
        public int QuiteHrsSatSun { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri_open")]
        public string QuiteHrsMonFriOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri_close")]
        public string QuiteHrsMonFriClose { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun_open")]
        public string QuiteHrsSatSunOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun_close")]
        public string QuiteHrsSatSunClose { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}