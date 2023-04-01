using System.Collections.Generic;

namespace Qloudid.Models
{
    public class ContactAddressDetail : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "zip_code")]
        private string zipCode;
        public string ZipCode
        {
            get => zipCode;
            set
            {
                zipCode = value;
                OnPropertyChanged("ZipCode");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city")]
        private string city;
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "state")]
        private string state;
        public string State
        {
            get => state;
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country")]
        private string country;
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "number")]
        private string number;
        public string Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private List<Models.Country> countryList;
        public List<Models.Country> CountryList
        {
            get => countryList;
            set
            {
                countryList = value;
                OnPropertyChanged("CountryList");
            }
        }

        private Models.Country selectedCountry;
        public Models.Country SelectedCountry
        {
            get => selectedCountry;
            set
            {
                selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }
        }

        private bool isRemove;
        public bool IsRemove
        {
            get => isRemove;
            set
            {
                isRemove = value;
                OnPropertyChanged("IsRemove");
            }
        }
    }
}
