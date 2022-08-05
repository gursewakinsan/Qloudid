using Xamarin.Forms;

namespace Qloudid.Models
{
    public class BathroomDetailResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_count")]
        public int BathroomCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_address_id")]
        public int UserAddressId { get; set; }

        
        [Newtonsoft.Json.JsonProperty(PropertyName = "toilet_and_sink")]
        public bool ToiletAndSink
        {
            get => toiletAndSink;
            set
            {
                toiletAndSink = value;
                OnPropertyChanged("ToiletAndSink");
                ToiletAndSinkBg = toiletAndSink ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
            }
        }
        private bool toiletAndSink;


        public Color toiletAndSinkBg;
        public Color ToiletAndSinkBg
        {
            get => toiletAndSinkBg;
            set
            {
                toiletAndSinkBg = value;
                OnPropertyChanged("ToiletAndSinkBg");
            }
        }



        [Newtonsoft.Json.JsonProperty(PropertyName = "bath")]
        public bool Bath
        {
            get => bath;
            set
            {
                bath = value;
                OnPropertyChanged("Bath");
                BathBg = bath ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
            }
        }
        private bool bath;

        public Color bathBg;
        public Color BathBg
        {
            get => bathBg;
            set
            {
                bathBg = value;
                OnPropertyChanged("BathBg");
            }
        }


        [Newtonsoft.Json.JsonProperty(PropertyName = "shower")]
        public bool Shower
        {
            get => shower;
            set
            {
                shower = value;
                OnPropertyChanged("Shower");
                ShowerBg = shower ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
            }
        }
        private bool shower;


        public Color showerBg;
        public Color ShowerBg
        {
            get => showerBg;
            set
            {
                showerBg = value;
                OnPropertyChanged("ShowerBg");
            }
        }
        

        [Newtonsoft.Json.JsonProperty(PropertyName = "standalone_shower")]
        public bool StandaloneShower
        {
            get => standaloneShower;
            set
            {
                standaloneShower = value;
                OnPropertyChanged("StandaloneShower");
            }
        }
        private bool standaloneShower;


        [Newtonsoft.Json.JsonProperty(PropertyName = "over_bath_shower")]
        public bool OverBathShower
        {
            get=> overBathShower;
            set
            {
                overBathShower = value;
                OnPropertyChanged("OverBathShower");
            }
        }
        private bool overBathShower;



        [Newtonsoft.Json.JsonProperty(PropertyName = "is_private")]
        public bool IsPrivate
        {
            get => isPrivate;
            set
            {
                isPrivate = value;
                OnPropertyChanged("IsPrivate");
                PrivateBg = isPrivate ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
            }
        }
        private bool isPrivate;

        public Color privateBg;
        public Color PrivateBg
        {
            get => privateBg;
            set
            {
                privateBg = value;
                OnPropertyChanged("PrivateBg");
            }
        }



        [Newtonsoft.Json.JsonProperty(PropertyName = "is_wheelchair_accessible")]
        public bool IsWheelchairAccessible
        {
            get => isWheelchairAccessible;
            set
            {
                isWheelchairAccessible = value;
                OnPropertyChanged("IsWheelchairAccessible");
                WheelchairAccessibleBg = isWheelchairAccessible ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
            }
        }
        private bool isWheelchairAccessible;

        public Color wheelchairAccessibleBg;
        public Color WheelchairAccessibleBg
        {
            get => wheelchairAccessibleBg;
            set
            {
                wheelchairAccessibleBg = value;
                OnPropertyChanged("WheelchairAccessibleBg");
            }
        }



        [Newtonsoft.Json.JsonProperty(PropertyName = "is_ensuit")]
        public bool IsEnsuit
        {
            get => isEnsuit;
            set
            {
                isEnsuit = value;
                OnPropertyChanged("IsEnsuit");
                EnsuitBg = isEnsuit ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
            }
        }
        private bool isEnsuit;

        public Color ensuitBg;
        public Color EnsuitBg
        {
            get => ensuitBg;
            set
            {
                ensuitBg = value;
                OnPropertyChanged("EnsuitBg");
            }
        }


        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }

       
        //public Color ToiletAndSinkBg => ToiletAndSink ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");


       // public Color ShowerBg => Shower ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        //public Color BathBg => Bath ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
        //public Color PrivateBg => IsPrivate ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
       // public Color EnsuitBg => IsEnsuit ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
       // public Color WheelchairAccessibleBg => IsWheelchairAccessible ? Color.FromHex("#0F9D58") : Color.FromHex("#191A20");
    }
}
