namespace Qloudid.Models
{
    public class ContactEmailDetail : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email_type")]
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
