namespace Qloudid.Models
{
    public class ContactCardDetail : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_type")]
        private string cardType;
        public string CardType
        {
            get => cardType;
            set
            {
                cardType = value;
                OnPropertyChanged("CardType");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "card_number")]
        private string cardNumber;
        public string CardNumber
        {
            get => cardNumber;
            set
            {
                cardNumber = value;
                OnPropertyChanged("CardNumber");
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
