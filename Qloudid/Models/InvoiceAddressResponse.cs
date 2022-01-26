using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Qloudid.Models
{
	public class InvoiceAddressResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "is_user")]
		public bool IsUser { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "index_id")]
		public string IndexId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
		public string NameOnHouse { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address")]
		public string InvoiceAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_city")]
		public string InvoiceCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_zip")]
		public string InvoiceZip { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_country")]
		public string InvoiceCountry { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_port_number")]
		public string InvoicePortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }


		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(NameOnHouse, 0).ToUpper();

		public string HeadingAddress => $"{InvoiceAddress} {InvoicePortNumber}";

		public string SubHeadingAddress => $"{InvoiceCity} {InvoiceZip}, {InvoiceCountry}";

		public string AddressForSearch => $"{NameOnHouse}, {UserName}, {HeadingAddress}, {SubHeadingAddress}";

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
		Color RandomColor()
		{
			Random randonGen = new Random();
			return Color.FromRgb(randonGen.Next(255), randonGen.Next(255),
			randonGen.Next(255));
		}

		private bool isSelect;
		public bool IsSelect
		{
			get { return isSelect; }
			set
			{
				if (isSelect != value)
				{
					isSelect = value;
					OnPropertyChanged("IsSelect");
					RowSelectedBg = IsSelect ? Color.FromHex("#E4FAF9") : Color.White;
					RowSelectedText = IsSelect ? Color.FromHex("#50B0C8") : Color.Black;
				}
			}
		}

		private Color rowSelectedBg;
		public Color RowSelectedBg
		{
			get { return rowSelectedBg; }
			set
			{
				rowSelectedBg = value;
				OnPropertyChanged("RowSelectedBg");
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

		private bool isPersonal;
		public bool IsPersonal
		{
			get { return isPersonal; }
			set
			{
				isPersonal = value;
				OnPropertyChanged("IsPersonal");
			}
		}

		private bool isBusiness;
		public bool IsBusiness
		{
			get { return isBusiness; }
			set
			{
				isBusiness = value;
				OnPropertyChanged("IsBusiness");
			}
		}

		public string UserName { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}

	public class InvoiceAddressInfo : List<InvoiceAddressResponse>
	{
		public string Heading { get; set; }
		public List<InvoiceAddressResponse> InvoiceAddress => this;
	}
}
