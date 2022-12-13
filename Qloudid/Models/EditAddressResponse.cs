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
	}
}
