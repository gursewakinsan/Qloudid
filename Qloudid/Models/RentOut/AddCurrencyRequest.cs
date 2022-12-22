namespace Qloudid.Models
{
    public class AddCurrencyRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "currency_id")]
        public int CurrencyId { get; set; }
    }
}
