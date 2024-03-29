﻿using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace Qloudid.Models
{
	public class DeliveryAddressesResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_address")]
		public List<UserAddress> UserAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_address")]
		public List<UserAddress> CompanyAddress { get; set; }
	}

	public class UserAddress : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }
		
		public int User_address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
		public string NameOnHouse { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "heading_address")]
		public string HeadingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "subheading_address")]
		public string SubHeadingAddress { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(NameOnHouse, 0).ToUpper();

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

	/*public class DeliveryAddressInfo : List<UserAddress>
	{
		public string Heading { get; set; }
		public List<UserAddress> DeliveryAddress => this;
	}*/
}
