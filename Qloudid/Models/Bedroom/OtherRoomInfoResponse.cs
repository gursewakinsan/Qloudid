namespace Qloudid.Models
{
    public class OtherRoomInfoResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "hall_room_available")]
        private bool hallRoomAvailable;
        public bool HallRoomAvailable
        {
            get=> hallRoomAvailable;
            set
            {
                hallRoomAvailable = value;
                OnPropertyChanged("HallRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "living_room_available")]
        private bool livingRoomAvailable;
        public bool LivingRoomAvailable
        {
            get => livingRoomAvailable;
            set
            {
                livingRoomAvailable = value;
                OnPropertyChanged("LivingRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_room_available")]
        private bool workRoomAvailable;
        public bool WorkRoomAvailable
        {
            get => workRoomAvailable;
            set
            {
                workRoomAvailable = value;
                OnPropertyChanged("WorkRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "hobby_room_available")]
        private bool hobbyRoomAvailable;
        public bool HobbyRoomAvailable
        {
            get => hobbyRoomAvailable;
            set
            {
                hobbyRoomAvailable = value;
                OnPropertyChanged("HobbyRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "sal_room_available")]
        private bool salRoomAvailable;
        public bool SalRoomAvailable
        {
            get => salRoomAvailable;
            set
            {
                salRoomAvailable = value;
                OnPropertyChanged("SalRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "salon_room_available")]
        private bool salonRoomAvailable;
        public bool SalonRoomAvailable
        {
            get => salonRoomAvailable;
            set
            {
                salonRoomAvailable = value;
                OnPropertyChanged("SalonRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "vestibule_room_available")]
        private bool vestibuleRoomAvailable;
        public bool VestibuleRoomAvailable
        {
            get => vestibuleRoomAvailable;
            set
            {
                vestibuleRoomAvailable = value;
                OnPropertyChanged("VestibuleRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dining_room_available")]
        private bool diningRoomAvailable;
        public bool DiningRoomAvailable
        {
            get => diningRoomAvailable;
            set
            {
                diningRoomAvailable = value;
                OnPropertyChanged("DiningRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "chamber_room_available")]
        private bool chamberRoomAvailable;
        public bool ChamberRoomAvailable
        {
            get => chamberRoomAvailable;
            set
            {
                chamberRoomAvailable = value;
                OnPropertyChanged("ChamberRoomAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "balcony_available")]
        private bool balconyAvailable;
        public bool BalconyAvailable
        {
            get => balconyAvailable;
            set
            {
                balconyAvailable = value;
                OnPropertyChanged("BalconyAvailable");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "terrace_available")]
        private bool terraceAvailable;
        public bool TerraceAvailable
        {
            get => terraceAvailable;
            set
            {
                terraceAvailable = value;
                OnPropertyChanged("TerraceAvailable");
            }
        }
    }
}
