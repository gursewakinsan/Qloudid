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
