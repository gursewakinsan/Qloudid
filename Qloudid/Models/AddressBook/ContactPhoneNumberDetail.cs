using System.Collections.Generic;

namespace Qloudid.Models
{
    public class ContactPhoneNumberDetail : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_type")]
        private string phoneType;
        public string PhoneType
        {
            get => phoneType;
            set
            {
                phoneType = value;
                OnPropertyChanged("PhoneType");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        [Newtonsoft.Json.JsonIgnore]
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

        [Newtonsoft.Json.JsonIgnore]
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

        private int isError;
        public int IsError
        {
            get => isError;
            set
            {
                isError = value;
                OnPropertyChanged("IsError");
            }
        }

        [Newtonsoft.Json.JsonIgnore]
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

        public int UserId { get; set; }
    }
}
