namespace Qloudid.Models
{
    public class NightlyPricingListResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pricing_title")]
        private string pricingTitle;
        public string PricingTitle
        {
            get => pricingTitle;
            set
            {
                pricingTitle = value;
                OnPropertyChanged("PricingTitle");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_deleted")]
        public bool IsDeleted { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pricingDate")]
        private string pricingDate;
        public string PricingDate
        {
            get => pricingDate;
            set
            {
                pricingDate = value;
                OnPropertyChanged("PricingDate");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum_price")]
        public int MinimumPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "maximum_price")]
        public int MaximumPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pricing_start_date")]
        private string pricingStartDate;
        public string PricingStartDate
        {
            get => pricingStartDate;
            set
            {
                pricingStartDate = value;
                OnPropertyChanged("PricingStartDate");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pricing_end_date")]
        private string pricingEndDate;
        public string PricingEndDate
        {
            get => pricingEndDate;
            set
            {
                pricingEndDate = value;
                OnPropertyChanged("PricingEndDate");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "monday_open")]
        private bool mondayOpen;
        public bool MondayOpen
        {
            get => mondayOpen;
            set
            {
                mondayOpen = value;
                OnPropertyChanged("MondayOpen");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tuesday_open")]
        private bool tuesdayOpen;
        public bool TuesdayOpen
        {
            get => tuesdayOpen;
            set
            {
                tuesdayOpen = value;
                OnPropertyChanged("TuesdayOpen");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wednesday_open")]
        private bool wednesdayOpen;
        public bool WednesdayOpen
        {
            get => wednesdayOpen;
            set
            {
                wednesdayOpen = value;
                OnPropertyChanged("WednesdayOpen");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "thursday_open")]
        private bool thursdayOpen;
        public bool ThursdayOpen
        {
            get => thursdayOpen;
            set
            {
                thursdayOpen = value;
                OnPropertyChanged("ThursdayOpen");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "friday_open")]
        private bool fridayOpen;
        public bool FridayOpen
        {
            get => fridayOpen;
            set
            {
                fridayOpen = value;
                OnPropertyChanged("FridayOpen");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "saturday_open")]
        private bool saturdayOpen;
        public bool SaturdayOpen
        {
            get => saturdayOpen;
            set
            {
                saturdayOpen = value;
                OnPropertyChanged("SaturdayOpen");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "sunday_open")]
        private bool sundayOpen;
        public bool SundayOpen
        {
            get => sundayOpen;
            set
            {
                sundayOpen = value;
                OnPropertyChanged("SundayOpen");
            }
        }


        [Newtonsoft.Json.JsonProperty(PropertyName = "shortest_duration")]
        private int shortestDuration;
        public int ShortestDuration
        {
            get => shortestDuration;
            set
            {
                shortestDuration = value;
                OnPropertyChanged("ShortestDuration");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "monday_price")]
        private int mondayPrice;
        public int MondayPrice
        {
            get => mondayPrice;
            set
            {
                mondayPrice = value;
                OnPropertyChanged("MondayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tuesday_price")]
        private int tuesdayPrice;
        public int TuesdayPrice
        {
            get => tuesdayPrice;
            set
            {
                tuesdayPrice = value;
                OnPropertyChanged("TuesdayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wednesday_price")]
        private int wednesdayPrice;
        public int WednesdayPrice
        {
            get => wednesdayPrice;
            set
            {
                wednesdayPrice = value;
                OnPropertyChanged("WednesdayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "thursday_price")]
        private int thursdayPrice;
        public int ThursdayPrice
        {
            get => thursdayPrice;
            set
            {
                thursdayPrice = value;
                OnPropertyChanged("ThursdayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "friday_price")]
        private int fridayPrice;
        public int FridayPrice
        {
            get => fridayPrice;
            set
            {
                fridayPrice = value;
                OnPropertyChanged("FridayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "saturday_price")]
        private int saturdayPrice;
        public int SaturdayPrice
        {
            get => saturdayPrice;
            set
            {
                saturdayPrice = value;
                OnPropertyChanged("SaturdayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "sunday_price")]
        private int sundayPrice;
        public int SundayPrice
        {
            get => sundayPrice;
            set
            {
                sundayPrice = value;
                OnPropertyChanged("SundayPrice");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "discount_for_seven")]
        private int discountForSeven;
        public int DiscountForSeven
        {
            get => discountForSeven;
            set
            {
                discountForSeven = value;
                OnPropertyChanged("DiscountForSeven");
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_address_id")]
        public int UserAddressId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }
    }
}



