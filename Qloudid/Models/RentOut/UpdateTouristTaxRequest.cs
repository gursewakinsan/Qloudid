namespace Qloudid.Models
{
    public class UpdateTouristTaxRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tourist_tax")]
        public string TouristTax { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tourist_tax_applicable")]
        public int TouristTaxApplicable { get; set; }
    }
}
