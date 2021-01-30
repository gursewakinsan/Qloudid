﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class AddDeliveryAddressViewModel : BaseViewModel
	{
		#region Constructor.
		public AddDeliveryAddressViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Address Command.
		private ICommand addAddressCommand;
		public ICommand AddAddressCommand
		{
			get => addAddressCommand ?? (addAddressCommand = new Command(async () => await ExecuteAddAddressCommand()));
		}
		private async Task ExecuteAddAddressCommand()
		{
			if (!IsNameSame && string.IsNullOrWhiteSpace(Name))
				await Helper.Alert.DisplayAlert("Name is required.");
			else if(string.IsNullOrWhiteSpace(DeliveryAddress))
				await Helper.Alert.DisplayAlert("Delivery address is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryPortNumber))
				await Helper.Alert.DisplayAlert("Delivery port number is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryZipCode))
				await Helper.Alert.DisplayAlert("Delivery zip code is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryCity))
				await Helper.Alert.DisplayAlert("Delivery city is required.");
			else if(!IsInvoiceAddressSame && string.IsNullOrWhiteSpace(InvoiceAddress))
				await Helper.Alert.DisplayAlert("Invoice address is required.");
			else if (!IsInvoiceAddressSame && string.IsNullOrWhiteSpace(InvoicePortNumber))
				await Helper.Alert.DisplayAlert("Invoice port number is required.");
			else if (!IsInvoiceAddressSame && string.IsNullOrWhiteSpace(InvoiceZipCode))
				await Helper.Alert.DisplayAlert("Invoice zip code is required.");
			else if (!IsInvoiceAddressSame && string.IsNullOrWhiteSpace(InvoiceCity))
				await Helper.Alert.DisplayAlert("Invoice city is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				if (IsNameSame) Name = UserName;
				if (IsInvoiceAddressSame)
				{
					InvoiceAddress = DeliveryAddress;
					InvoicePortNumber = DeliveryPortNumber;
					InvoiceZipCode = DeliveryZipCode;
					InvoiceCity = DeliveryCity;
				}
				ICreateAccountService service = new CreateAccountService();
				Models.AddDeliveryAddressRequest request = new Models.AddDeliveryAddressRequest()
				{
					CertificateKey = Helper.Helper.QrCertificateKey,
					UserId = Helper.Helper.UserId,
					Name = Name,
					DeliveryAddress = DeliveryAddress,
					DeliveryPortNumber = DeliveryPortNumber,
					DeliveryZipCode = DeliveryZipCode,
					DeliveryCity = DeliveryCity,
					InvoiceAddress = InvoiceAddress,
					InvoicePortNumber = InvoicePortNumber,
					InvoiceZipCode = InvoiceZipCode,
					InvoiceCity = InvoiceCity,
					EntryCode = EntryCode,
					IsNameSame = IsNameSame,
					IsInvoiceAddressSame = IsInvoiceAddressSame
				};
				int response = await service.AddDeliveryAddressAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
				else if (response == 1)
				{
					if (Helper.Helper.IsAddMoreAddresses)
					{
						Helper.Helper.IsAddMoreAddresses = false;
						//await Navigation.PopAsync();
						Application.Current.MainPage = new NavigationPage(new Views.PurchasePage());
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private bool isNameSame = true;
		public bool IsNameSame 
		{
			get => isNameSame;
			set
			{
				isNameSame = value;
				IsNameEntryVisible = !isNameSame;
				OnPropertyChanged("IsNameSame");
			}
		}

		private bool isNameEntryVisible;
		public bool IsNameEntryVisible
		{
			get => isNameEntryVisible;
			set
			{
				isNameEntryVisible = value;
				OnPropertyChanged("IsNameEntryVisible");
			}
		}

		private bool isInvoiceAddressSame = true;
		public bool IsInvoiceAddressSame
		{
			get => isInvoiceAddressSame;
			set
			{
				isInvoiceAddressSame = value;
				IsInvoiceAddressVisible = !isInvoiceAddressSame;
				OnPropertyChanged("IsInvoiceAddressSame");
			}
		}

		private bool isInvoiceAddressVisible;
		public bool IsInvoiceAddressVisible
		{
			get => isInvoiceAddressVisible;
			set
			{
				isInvoiceAddressVisible = value;
				OnPropertyChanged("IsInvoiceAddressVisible");
			}
		}
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		public bool IsCloseShow => Helper.Helper.IsAddMoreAddresses;
		public string Name { get; set; }
		public string DeliveryAddress { get; set; }
		public string DeliveryPortNumber { get; set; }
		public string DeliveryZipCode { get; set; }
		public string DeliveryCity { get; set; }
		public string InvoiceAddress { get; set; }
		public string InvoicePortNumber { get; set; }
		public string InvoiceZipCode { get; set; }
		public string InvoiceCity { get; set; }
		public string EntryCode { get; set; }
		#endregion
	}
}

