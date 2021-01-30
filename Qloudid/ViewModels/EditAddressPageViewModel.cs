using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
namespace Qloudid.ViewModels
{
	public class EditAddressPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EditAddressPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Address By Id Command.
		private ICommand getAddressByIdCommand;
		public ICommand GetAddressByIdCommand
		{
			get => getAddressByIdCommand ?? (getAddressByIdCommand = new Command(async () => await ExecuteGetAddressByIdCommand()));
		}
		private async Task ExecuteGetAddressByIdCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			Address = null;
			if (Helper.Helper.DeliveryAddress.UserAddress == 1)
				Address = await service.GetAddressByIdAsync(new Models.EditAddressRequest() { id = Helper.Helper.DeliveryAddress.Id });
			else
				Address = await service.GetCompanyAddressByIdAsync(new Models.EditAddressRequest() { id = Helper.Helper.DeliveryAddress.Id });
			UserName = Address.NameOnHouse;
			IsNameSame = Address.IsNameSame == 1 ? true : false;
			Name = Address.NameOnHouse;
			DeliveryAddress = Address.Address;
			DeliveryPortNumber = Address.PortNumber;
			DeliveryZipCode = Address.Zipcode;
			DeliveryCity = Address.City;
			IsInvoiceAddressSame = Address.IsInvoiceSame == 1 ? true : false;
			InvoiceAddress = Address.InvoiceAddress;
			InvoicePortNumber = Address.InvoicePortNumber;
			InvoiceZipCode = Address.InvoiceZipcode;
			InvoiceCity = Address.InvoiceCity;
			EntryCode = Address.EntryCode;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Address Command.
		private ICommand updateUserAddressCommand;
		public ICommand UpdateUserAddressCommand
		{
			get => updateUserAddressCommand ?? (updateUserAddressCommand = new Command(async () => await ExecuteUpdateUserAddressCommand()));
		}
		private async Task ExecuteUpdateUserAddressCommand()
		{
			if (Helper.Helper.DeliveryAddress.UserAddress == 1)
				await UpdateUserAddress();
			else
				await UpdateCompanyAddress();
		}
		private async Task UpdateCompanyAddress()
		{
			IDashboardService service = new DashboardService();
			Address.CertificateKey = Helper.Helper.QrCertificateKey;
			Address.UserId = Helper.Helper.UserId;
			int response = await service.UpdateCompanyAddressAsync(Address);
			if (response == 0)
				await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
			else if (response == 1)
				Application.Current.MainPage = new NavigationPage(new Views.PurchasePage());
			DependencyService.Get<IProgressBar>().Hide();
		}

		private async Task UpdateUserAddress()
		{
			if (!IsNameSame && string.IsNullOrWhiteSpace(Name))
				await Helper.Alert.DisplayAlert("Name is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryAddress))
				await Helper.Alert.DisplayAlert("Delivery address is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryPortNumber))
				await Helper.Alert.DisplayAlert("Delivery port number is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryZipCode))
				await Helper.Alert.DisplayAlert("Delivery zip code is required.");
			else if (string.IsNullOrWhiteSpace(DeliveryCity))
				await Helper.Alert.DisplayAlert("Delivery city is required.");
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
				if (IsNameSame) Name = UserName;
				if (IsInvoiceAddressSame)
				{
					InvoiceAddress = DeliveryAddress;
					InvoicePortNumber = DeliveryPortNumber;
					InvoiceZipCode = DeliveryZipCode;
					InvoiceCity = DeliveryCity;
				}
				IDashboardService service = new DashboardService();
				Models.EditAddressResponse request = new Models.EditAddressResponse()
				{
					CertificateKey = Helper.Helper.QrCertificateKey,
					Id = Helper.Helper.DeliveryAddress.Id,
					UserId = Helper.Helper.UserId,
					NameOnHouse = Name,
					Address = DeliveryAddress,
					PortNumber = DeliveryPortNumber,
					Zipcode = DeliveryZipCode,
					City = DeliveryCity,
					InvoiceAddress = InvoiceAddress,
					InvoicePortNumber = InvoicePortNumber,
					InvoiceZipcode = InvoiceZipCode,
					InvoiceCity = InvoiceCity,
					EntryCode = EntryCode,
					IsNameSame = IsNameSame ? 1 : 0,
					IsInvoiceSame = IsInvoiceAddressSame ? 1 : 0
				};
				int response = await service.UpdateUserAddressAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response == 1)
					Application.Current.MainPage = new NavigationPage(new Views.PurchasePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private bool isNameSame;
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

		private bool isInvoiceAddressSame;
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
		public bool IsAddressIsReadOnly => Helper.Helper.DeliveryAddress.UserAddress == 1 ? false : true;

		private string userName;
		public string UserName
		{
			get => userName;
			set
			{
				userName = value;
				OnPropertyChanged("UserName");
			}
		}

		private string name;
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		private string deliveryAddress;
		public string DeliveryAddress
		{
			get => deliveryAddress;
			set
			{
				deliveryAddress = value;
				OnPropertyChanged("DeliveryAddress");
			}
		}

		private string deliveryPortNumber;
		public string DeliveryPortNumber
		{
			get => deliveryPortNumber;
			set
			{
				deliveryPortNumber = value;
				OnPropertyChanged("DeliveryPortNumber");
			}
		}

		private string deliveryZipCode;
		public string DeliveryZipCode
		{
			get => deliveryZipCode;
			set
			{
				deliveryZipCode = value;
				OnPropertyChanged("DeliveryZipCode");
			}
		}

		private string deliveryCity;
		public string DeliveryCity
		{
			get => deliveryCity;
			set
			{
				deliveryCity = value;
				OnPropertyChanged("DeliveryCity");
			}
		}

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

		private string entryCode;
		public string EntryCode
		{
			get => entryCode;
			set
			{
				entryCode = value;
				OnPropertyChanged("EntryCode");
			}
		}

		public Models.EditAddressResponse Address { get; set; }
		#endregion
	}
}
