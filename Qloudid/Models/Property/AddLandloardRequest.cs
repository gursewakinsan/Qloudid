namespace Qloudid.Models
{
    public class AddLandloardRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_email")]
        public string CompanyEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "manager_email")]
        public string ManagerEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "chairmen_email")]
        public string ChairmenEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "vice_chairmen_email")]
        public string ViceChairmenEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "secratory_email")]
        public string SecratoryEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "b_id")]
        public int BId { get; set; }
    }
}
