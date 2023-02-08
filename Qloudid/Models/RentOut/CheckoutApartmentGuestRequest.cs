namespace Qloudid.Models
{
    public class CheckoutApartmentGuestRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "actual_checkout_date")]
        public string ActualCheckoutDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkout_id")]
        public int CheckoutId { get; set; }
    }
}
