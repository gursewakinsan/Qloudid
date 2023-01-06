using Xamarin.Forms;

namespace Qloudid.Models
{
	public class EditAddressResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
		public string Zipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
		public string PortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address")]
		public string InvoiceAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_city")]
		public string InvoiceCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_zipcode")]
		public string InvoiceZipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_port_number")]
		public string InvoicePortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_name_same")]
		public int IsNameSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_invoice_same")]
		public int IsInvoiceSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
		public string NameOnHouse { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_personal_address")]
		public int IsPersonalAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "entry_code")]
		public string EntryCode { get; set; }
		public string CertificateKey { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "delivered_at")]
		public int DeliveredAt { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wi_fi_updated")]
		public bool IsWiFiUpdated { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_available")]
		public bool IsWifiAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_username")]
		public string WifiUsername { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_password")]
		public string WifiPassword { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_floor")]
		public int ApartmentFloor { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "arrival_time")]
		public string ArrivalTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "departure_time")]
		public string DepartureTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "currency_updated")]
		public bool IsCurrencyUpdated { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_layout")]
		private string propertyLayout;
		public string PropertyLayout
		{
			get => propertyLayout;
			set
			{
				propertyLayout = value;
				OnPropertyChanged("PropertyLayout");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_type")]
		private int propertyType;
		public int PropertyType
		{
			get => propertyType;
			set
			{
				propertyType = value;
				OnPropertyChanged("PropertyType");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "floors_available")]
		private string floorsAvailable;
		public string FloorsAvailable
		{
			get => floorsAvailable;
			set
			{
				floorsAvailable = value;
				OnPropertyChanged("FloorsAvailable");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "entrance_floor")]
		private int entranceFloor;
		public int EntranceFloor
		{
			get => entranceFloor;
			set
			{
				entranceFloor = value;
				OnPropertyChanged("EntranceFloor");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "private_entrance")]
		private bool privateEntrance;
		public bool PrivateEntrance
		{
			get => privateEntrance;
			set
			{
				privateEntrance = value;
				OnPropertyChanged("PrivateEntrance");
			}
		}

		private Color privateEntranceBg;
		public Color PrivateEntranceBg
		{
			get => privateEntranceBg;
			set
			{
				privateEntranceBg = value;
				OnPropertyChanged("PrivateEntranceBg");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "elevator")]
		private bool elevator;
		public bool Elevator
		{
			get => elevator;
			set
			{
				elevator = value;
				OnPropertyChanged("Elevator");
			}
		}

		private Color elevatorBg;
		public Color ElevatorBg
		{
			get => elevatorBg;
			set
			{
				elevatorBg = value;
				OnPropertyChanged("ElevatorBg");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "bedroom_updated")]
		private bool bedroomUpdated;
		public bool BedroomUpdated
		{
			get => bedroomUpdated;
			set
			{
				bedroomUpdated = value;
				OnPropertyChanged("BedroomUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "bathroom_updated")]
		private bool bathroomUpdated;
		public bool BathroomUpdated
		{
			get => bathroomUpdated;
			set
			{
				bathroomUpdated = value;
				OnPropertyChanged("BathroomUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_composition_updated")]
		private bool propertyCompositionUpdated;
		public bool PropertyCompositionUpdated
		{
			get => propertyCompositionUpdated;
			set
			{
				propertyCompositionUpdated = value;
				OnPropertyChanged("PropertyCompositionUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "other_room_updated")]
		private bool otherRoomUpdated;
		public bool OtherRoomUpdated
		{
			get => otherRoomUpdated;
			set
			{
				otherRoomUpdated = value;
				OnPropertyChanged("OtherRoomUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "arrival_departure_updated")]
		private bool arrivalDepartureUpdated;
		public bool ArrivalDepartureUpdated
		{
			get => arrivalDepartureUpdated;
			set
			{
				arrivalDepartureUpdated = value;
				OnPropertyChanged("ArrivalDepartureUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "house_rules_updated")]
		private bool houseRulesUpdated;
		public bool HouseRulesUpdated
		{
			get => houseRulesUpdated;
			set
			{
				houseRulesUpdated = value;
				OnPropertyChanged("HouseRulesUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "children_allowed")]
		private bool childrenAllowed;
		public bool ChildrenAllowed
		{
			get => childrenAllowed;
			set
			{
				childrenAllowed = value;
				OnPropertyChanged("ChildrenAllowed");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "infants_allowed")]
		private bool infantsAllowed;
		public bool InfantsAllowed
		{
			get => infantsAllowed;
			set
			{
				infantsAllowed = value;
				OnPropertyChanged("InfantsAllowed");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "smoking_allowed")]
		private bool smokingAllowed;
		public bool SmokingAllowed
		{
			get => smokingAllowed;
			set
			{
				smokingAllowed = value;
				OnPropertyChanged("SmokingAllowed");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "events_allowed")]
		private bool eventsAllowed;
		public bool EventsAllowed
		{
			get => eventsAllowed;
			set
			{
				eventsAllowed = value;
				OnPropertyChanged("EventsAllowed");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "pets_allowed")]
		private bool petsAllowed;
		public bool PetsAllowed
		{
			get => petsAllowed;
			set
			{
				petsAllowed = value;
				OnPropertyChanged("PetsAllowed");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs")]
		private bool quiteHrs;
		public bool QuiteHrs
		{
			get => quiteHrs;
			set
			{
				quiteHrs = value;
				OnPropertyChanged("QuiteHrs");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri")]
		private bool quiteHrsMonFri;
		public bool QuiteHrsMonFri
		{
			get => quiteHrsMonFri;
			set
			{
				quiteHrsMonFri = value;
				OnPropertyChanged("QuiteHrsMonFri");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun")]
		private bool quiteHrsSatSun;
		public bool QuiteHrsSatSun
		{
			get => quiteHrsSatSun;
			set
			{
				quiteHrsSatSun = value;
				OnPropertyChanged("QuiteHrsSatSun");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri_open")]
		private string quiteHrsMonFriOpen;
		public string QuiteHrsMonFriOpen
		{
			get => quiteHrsMonFriOpen;
			set
			{
				quiteHrsMonFriOpen = value;
				OnPropertyChanged("QuiteHrsMonFriOpen");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri_close")]
		private string quiteHrsMonFriClose;
		public string QuiteHrsMonFriClose
		{
			get => quiteHrsMonFriClose;
			set
			{
				quiteHrsMonFriClose = value;
				OnPropertyChanged("QuiteHrsMonFriClose");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun_open")]
		private string quiteHrsSatSunOpen;
		public string QuiteHrsSatSunOpen
		{
			get => quiteHrsSatSunOpen;
			set
			{
				quiteHrsSatSunOpen = value;
				OnPropertyChanged("QuiteHrsSatSunOpen");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun_close")]
		private string quiteHrsSatSunClose;
		public string QuiteHrsSatSunClose
		{
			get => quiteHrsSatSunClose;
			set
			{
				quiteHrsSatSunClose = value;
				OnPropertyChanged("QuiteHrsSatSunClose");
			}
		}

		private Color childrenAllowedBg;
		public Color ChildrenAllowedBg
		{
			get => childrenAllowedBg;
			set
			{
				childrenAllowedBg = value;
				OnPropertyChanged("ChildrenAllowedBg");
			}
		}

		private Color infantsAllowedBg;
		public Color InfantsAllowedBg
		{
			get => infantsAllowedBg;
			set
			{
				infantsAllowedBg = value;
				OnPropertyChanged("InfantsAllowedBg");
			}
		}

		private Color smokingAllowedBg;
		public Color SmokingAllowedBg
		{
			get => smokingAllowedBg;
			set
			{
				smokingAllowedBg = value;
				OnPropertyChanged("SmokingAllowedBg");
			}
		}

		private Color eventsAllowedBg;
		public Color EventsAllowedBg
		{
			get => eventsAllowedBg;
			set
			{
				eventsAllowedBg = value;
				OnPropertyChanged("EventsAllowedBg");
			}
		}

		private Color petsAllowedBg;
		public Color PetsAllowedBg
		{
			get => petsAllowedBg;
			set
			{
				petsAllowedBg = value;
				OnPropertyChanged("PetsAllowedBg");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "cleening_fee_applicable")]
		private bool cleeningFeeApplicable;
		public bool CleeningFeeApplicable
		{
			get => cleeningFeeApplicable;
			set
			{
				cleeningFeeApplicable = value;
				OnPropertyChanged("CleeningFeeApplicable");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "cleening_fee")]
		private int cleeningFee;
		public int CleeningFee
		{
			get => cleeningFee;
			set
			{
				cleeningFee = value;
				OnPropertyChanged("CleeningFee");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee_applicable")]
		private bool securityFeeApplicable;
		public bool SecurityFeeApplicable
		{
			get => securityFeeApplicable;
			set
			{
				securityFeeApplicable = value;
				OnPropertyChanged("SecurityFeeApplicable");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee")]
		private int securityFee;
		public int SecurityFee
		{
			get => securityFee;
			set
			{
				securityFee = value;
				OnPropertyChanged("SecurityFee");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee_updated")]
		private bool securityFeeUpdated;
		public bool SecurityFeeUpdated
		{
			get => securityFeeUpdated;
			set
			{
				securityFeeUpdated = value;
				OnPropertyChanged("SecurityFeeUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "policy_updated")]
		private bool policyUpdated;
		public bool PolicyUpdated
		{
			get => policyUpdated;
			set
			{
				policyUpdated = value;
				OnPropertyChanged("PolicyUpdated");
			}
		}
		

		[Newtonsoft.Json.JsonProperty(PropertyName = "fee_updated")]
		private bool feeUpdated;
		public bool FeeUpdated
		{
			get => feeUpdated;
			set
			{
				feeUpdated = value;
				OnPropertyChanged("FeeUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "pricing_updated")]
		private bool pricingUpdated;
		public bool PricingUpdated
		{
			get => pricingUpdated;
			set
			{
				pricingUpdated = value;
				OnPropertyChanged("PricingUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
		private string propertyNickname;
		public string PropertyNickname
		{
			get => propertyNickname;
			set
			{
				propertyNickname = value;
				OnPropertyChanged("PropertyNickname");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_heading")]
		private string propertyHeading;
		public string PropertyHeading
		{
			get => propertyHeading;
			set
			{
				propertyHeading = value;
				OnPropertyChanged("PropertyHeading");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_description")]
		private string apartmentDescription;
		public string ApartmentDescription
		{
			get => apartmentDescription;
			set
			{
				apartmentDescription = value;
				OnPropertyChanged("ApartmentDescription");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "nickname_updated")]
		private bool nicknameUpdated;
		public bool NicknameUpdated
		{
			get => nicknameUpdated;
			set
			{
				nicknameUpdated = value;
				OnPropertyChanged("NicknameUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "headline_updated")]
		private bool headLineUpdated;
		public bool HeadLineUpdated
		{
			get => headLineUpdated;
			set
			{
				headLineUpdated = value;
				OnPropertyChanged("HeadLineUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "description_updated")]
		private bool descriptionUpdated;
		public bool DescriptionUpdated
		{
			get => descriptionUpdated;
			set
			{
				descriptionUpdated = value;
				OnPropertyChanged("DescriptionUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "get_started_updated")]
		private int getStartedUpdated;
		public int GetStartedUpdated
		{
			get => getStartedUpdated;
			set
			{
				getStartedUpdated = value;
				OnPropertyChanged("GetStartedUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "tourist_tax_updated")]
		private bool touristTaxUpdated;
		public bool TouristTaxUpdated
		{
			get => touristTaxUpdated;
			set
			{
				touristTaxUpdated = value;
				OnPropertyChanged("TouristTaxUpdated");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "tourist_tax_applicable")]
		private bool touristTaxApplicable;
		public bool TouristTaxApplicable
		{
			get => touristTaxApplicable;
			set
			{
				touristTaxApplicable = value;
				OnPropertyChanged("TouristTaxApplicable");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "tourist_tax")]
		private string touristTax;
		public string TouristTax
		{
			get => touristTax;
			set
			{
				touristTax = value;
				OnPropertyChanged("TouristTax");
			}
		}
	}
}