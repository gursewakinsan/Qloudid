namespace Qloudid.Models
{
    public class IdentificatorCountDetailResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "passport_count")]
        private bool passportCount;
        public bool PassportCount
        {
            get => passportCount;
            set
            {
                passportCount = value;
                OnPropertyChanged("PassportCount");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "national_card_count")]
        public bool nationalCardCount;
        public bool NationalCardCount
        {
            get => nationalCardCount;
            set
            {
                nationalCardCount = value;
                OnPropertyChanged("NationalCardCount");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dl_count")]
        private bool dlCount;
        public bool DlCount
        {
            get => dlCount;
            set
            {
                dlCount = value;
                OnPropertyChanged("DlCount");
            }
        }
    }
}