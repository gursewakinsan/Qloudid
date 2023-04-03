using System.Collections.Generic;

namespace Qloudid.Models
{
    public class UserAddessBookContactDetailInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_first_name")]
        public string ContactFirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_last_name")]
        public string ContactLastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_relation")]
        public string ContactRelation { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_image")]
        public string ContactImage { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "emails")]
        public List<Email> Emails { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phones")]
        public List<Phone> Phones { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "addresses")]
        public List<Address> Addresses { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cards")]
        public List<Card> Cards { get; set; }
    }

    public class Address
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_street_address")]
        public string ContactStreetAddress { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_port_number")]
        public string ContactPortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_zip")]
        public string ContactZip { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_city")]
        public string ContactCity { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_state")]
        public string ContactState { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_country")]
        public string ContactCountry { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_contact_address_book_id")]
        public int UserContactAddressBookId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_address_type")]
        public int ContactAddressType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }
    }

    public class Card
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_card_number")]
        public string ContactCardNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_contact_address_book_id")]
        public int UserContactAddressBookId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_card_type")]
        public string ContactCardType { get; set; }
    }

    public class Email
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_email")]
        public string ContactEmail { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_contact_address_book_id")]
        public int UserContactAddressBookId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_email_type")]
        public string ContactEmailType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
    }

    public class Phone
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_country_id")]
        public int ContactCountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_phone_number")]
        public long ContactPhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "contact_phone_number_type")]
        public string ContactPhoneNumberType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_contact_address_book_id")]
        public int UserContactAddressBookId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_code")]
        public int CountryCode { get; set; }
    }
}

