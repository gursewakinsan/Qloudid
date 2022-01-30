using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Qloudid.Models
{
	public class PickupAddressDetailResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
		public string PortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
		public string Zipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "pickup_address_name")]
		public string PickupAddressName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_name")]
		public string CountryName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		public string AddressForSearch => $"{PickupAddressName}, {Address}, {PortNumber}, {City}, {Zipcode},{CountryName}";

		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(PickupAddressName, 0).ToUpper();

		private string firstLetterNameBg;
		public string FirstLetterNameBg
		{
			get { return firstLetterNameBg; }
			set
			{
				firstLetterNameBg = value;
				OnPropertyChanged("FirstLetterNameBg");
			}
		}

		private Color rowSelectedText = Color.Black;
		public Color RowSelectedText
		{
			get { return rowSelectedText; }
			set
			{
				rowSelectedText = value;
				OnPropertyChanged("RowSelectedText");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}

	public class PickupAddressDetailInfo : List<PickupAddressDetailResponse>
	{
		public string Heading { get; set; }
		public List<PickupAddressDetailResponse> PickupAddress => this;
	}
}
