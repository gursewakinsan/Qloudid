using System.Collections.Generic;

namespace Qloudid.Models
{
    public class ContactEmailDetail : BaseModel
    {
        public int Id { get; set; }

        private string emailType;
        public string EmailType
        {
            get => emailType;
            set
            {
                emailType = value;
                OnPropertyChanged("EmailType");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
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
