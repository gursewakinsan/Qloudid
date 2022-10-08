using System.Collections.Generic;

namespace Qloudid.Models
{
    public class ReceivedRequestDetailTenantsResponse
    {
        //[Newtonsoft.Json.JsonProperty(PropertyName = "sent")]
        //public List<RequestDetail> RequestSentDetail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "received")]
        public List<TenantsRequestDetail> RequestReceivedDetail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "approved")]
        public List<TenantsRequestDetail> RequestApprovedDetail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "rejected")]
        public List<TenantsRequestDetail> RequestRejectedDetail { get; set; }
    }

    public class TenantsRequestDetail
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "building_name")]
        public string BuildingName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_approved")]
        public int IsApproved { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "office_apartment_number")]
        public int OfficeApartmentNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        public string ActionName { get; set; }
        public bool IsRequestReceived { get; set; }
        public Xamarin.Forms.Color RowBg { get; set; }
    }
}
