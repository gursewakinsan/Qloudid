namespace Qloudid.Models
{
    public class UpdateOwnerInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "property_type")]
        public int PropertyType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ownership_detail")]
        public int OwnershipDetail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bought_by_you")]
        public int BoughtByYou { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bought_rent_allowed")]
        public int BoughtRentAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "rent_contract_on_you")]
        public int RentContractOnYou { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "allowed_to_rent_out")]
        public int AllowedToRentOut { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}