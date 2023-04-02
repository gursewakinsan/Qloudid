using System.Collections.Generic;

namespace Qloudid.Models
{
    public class AddContactInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email_info")]
        public List<EmailInfo> EmailInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_info")]
        public List<PhoneInfo> PhoneInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address_info")]
        public List<AddressInfo> AddressInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_info")]
        public List<CardInfo> CardInfo { get; set; }
    }

    public class EmailInfo
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "email_address")]
        public string EmailAddress { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email_type")]
        public string EmailType { get; set; }
    }

    public class PhoneInfo
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "country_code")]
        public int CountryCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_type")]
        public string PhoneType { get; set; }
    }

    public class AddressInfo
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "code_number")]
        public string CodeNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "zip_code")]
        public string ZipCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_code")]
        public int CountryCode { get; set; }
    }

    public class CardInfo
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "card_number")]
        public string CardNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_type")]
        public string CardType { get; set; }
    }
}
