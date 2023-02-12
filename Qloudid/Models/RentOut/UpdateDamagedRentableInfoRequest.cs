namespace Qloudid.Models
{
    public class UpdateDamagedRentableInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_cleened")]
        public int IsCleened { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "if_damaged")]
        public int IfDamaged { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "if_rentable")]
        public int IfRentable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "checkout_id")]
        public int CheckoutId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cleening_date")]
        public string CleeningDate { get; set; }
    }
}
