using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ProfileEnterPropertyDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ProfileEnterPropertyDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Profile Command.
		private ICommand addProfileCommand;
		public ICommand AddProfileCommand
		{
			get => addProfileCommand ?? (addProfileCommand = new Command(async () => await ExecuteAddProfileCommand()));
		}
		private async Task ExecuteAddProfileCommand()
		{
			if (IsEntryCode && string.IsNullOrWhiteSpace(Code))
				await Helper.Alert.DisplayAlert("Code is required.");
			else if (string.IsNullOrWhiteSpace(NameOnTheDoor))
				await Helper.Alert.DisplayAlert("Name on the door is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryAddress))
				await Helper.Alert.DisplayAlert("Delivery address is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryPortNumber))
				await Helper.Alert.DisplayAlert("Delivery port number is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryZipCode))
				await Helper.Alert.DisplayAlert("Delivery zip code is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryCity))
				await Helper.Alert.DisplayAlert("Delivery city is required.");
			//else if (!IsInvoiceAddressSame && string.IsNullOrWhiteSpace(NameOnTheCard))
			//	await Helper.Alert.DisplayAlert("Name on the card is required.");
			else if (!IsInvoiceAddressSame && string.IsNullOrWhiteSpace(InvoiceAddress))
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
					EntryCode = EntryCode,
					Name = NameOnTheDoor,
					DeliveryAddress = DeliveryAddress,
					DeliveryPortNumber = DeliveryPortNumber,
					DeliveryZipCode = DeliveryZipCode,
					DeliveryCity = DeliveryCity,
					InvoiceAddress = InvoiceAddress,
					InvoicePortNumber = InvoicePortNumber,
					InvoiceZipCode = InvoiceZipCode,
					InvoiceCity = InvoiceCity,
					IsNameSame = IsNameSame,
					IsInvoiceAddressSame = IsInvoiceAddressSame
				};
				int response = await service.AddDeliveryAddressAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
				else
				{
					this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
					await Navigation.PopAsync();
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Is Invoice Address Same Command.
		private ICommand isInvoiceAddressSameCommand;
		public ICommand IsInvoiceAddressSameCommand
		{
			get => isInvoiceAddressSameCommand ?? (isInvoiceAddressSameCommand = new Command(() => ExecuteIsInvoiceAddressSameCommand()));
		}
		private void ExecuteIsInvoiceAddressSameCommand()
		{
			IsInvoiceAddressSame = !IsInvoiceAddressSame;
		}
		#endregion

		#region Is Entry Code Command.
		private ICommand isEntryCodeCommand;
		public ICommand IsEntryCodeCommand
		{
			get => isEntryCodeCommand ?? (isEntryCodeCommand = new Command(() => ExecuteIsEntryCodeCommand()));
		}
		private void ExecuteIsEntryCodeCommand()
		{
			IsEntryCode = !IsEntryCode;
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

		private bool isEntryCode = true;
		public bool IsEntryCode
		{
			get => isEntryCode;
			set
			{
				isEntryCode = value;
				OnPropertyChanged("IsEntryCode");
			}
		}

		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		public bool IsCloseShow => Helper.Helper.IsAddMoreAddresses;
		public string Code { get; set; }
        public string NameOnTheDoor { get; set; }
		public string DeliveryAddress { get; set; }
		public string DeliveryPortNumber { get; set; }
		public string DeliveryZipCode { get; set; }
		public string DeliveryCity { get; set; }

		private string invoiceAddress;
		public string InvoiceAddress
		{
			get => invoiceAddress;
			set
			{
				invoiceAddress = value;
				OnPropertyChanged("InvoiceAddress");
			}
		}

		private string invoicePortNumber;
		public string InvoicePortNumber
		{
			get => invoicePortNumber;
			set
			{
				invoicePortNumber = value;
				OnPropertyChanged("InvoicePortNumber");
			}
		}

		private string invoiceZipCode;
		public string InvoiceZipCode
		{
			get => invoiceZipCode;
			set
			{
				invoiceZipCode = value;
				OnPropertyChanged("InvoiceZipCode");
			}
		}

		private string invoiceCity;
		public string InvoiceCity
		{
			get => invoiceCity;
			set
			{
				invoiceCity = value;
				OnPropertyChanged("InvoiceCity");
			}
		}
		public string EntryCode { get; set; }
		#endregion
	}
}
