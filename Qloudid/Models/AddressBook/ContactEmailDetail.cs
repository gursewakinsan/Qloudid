using System.Collections.Generic;

namespace Qloudid.Models
{
    public class ContactEmailDetail : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email_address")]
        private string emailAddress;
        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }

        private List<Models.EmailTypeInfo> emailTypeInfoList;
        public List<Models.EmailTypeInfo> EmailTypeInfoList
        {
            get => emailTypeInfoList;
            set
            {
                emailTypeInfoList = value;
                OnPropertyChanged("EmailTypeInfoList");
            }
        }

        private Models.EmailTypeInfo selectedEmailTypeInfo;
        public Models.EmailTypeInfo SelectedEmailTypeInfo
        {
            get => selectedEmailTypeInfo;
            set
            {
                selectedEmailTypeInfo = value;
                OnPropertyChanged("SelectedEmailTypeInfo");
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
