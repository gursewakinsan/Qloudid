using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class WhoIsPayingPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WhoIsPayingPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Invoice Address Command.
		private ICommand getInvoiceAddressCommand;
		public ICommand GetInvoiceAddressCommand
		{
			get => getInvoiceAddressCommand ?? (getInvoiceAddressCommand = new Command(async () => await ExecuteGetInvoiceAddressCommand()));
		}
		private async Task ExecuteGetInvoiceAddressCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.GetInvoiceAddressAsync(new Models.InvoiceAddressRequest() { UserId = Helper.Helper.UserId });
			var list = new List<Models.InvoiceAddressResponse>();
			if (response?.Count > 0)
			{
				foreach (var item in response)
				{
					if (item.IsUser)
					{
						item.UserName = string.Empty;
						item.IsPersonal = true;
						item.IsBusiness = false;
						list.Add(item);
					}
					else
					{
						item.UserName = UserName;
						item.IsPersonal = false;
						item.IsBusiness = false;
						list.Add(item);
					}
				}
			}
			CopyInvoiceAddress = list;
			ListOfInvoiceAddress = new ObservableCollection<Models.InvoiceAddressResponse>(list);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Show Personal Addresses Command.
		private ICommand showPersonalAddressesCommand;
		public ICommand ShowPersonalAddressesCommand
		{
			get => showPersonalAddressesCommand ?? (showPersonalAddressesCommand = new Command(async () => await ExecuteShowPersonalAddressesCommand()));
		}
		private async Task ExecuteShowPersonalAddressesCommand()
		{
			IsPersonalOrBusiness = true;
			BtnPersonalBg = "#0F9D58";
			BtnBusinessBg = "#2A2A31";
			foreach (var personalAddresses in CopyInvoiceAddress)
			{
				personalAddresses.IsBusiness = false;
				if (personalAddresses.IsUser)
					personalAddresses.IsPersonal = true;
				else
					personalAddresses.IsPersonal = false;
			}
			ListOfInvoiceAddress = new ObservableCollection<Models.InvoiceAddressResponse>(CopyInvoiceAddress);
			await Task.CompletedTask;
		}
		#endregion

		#region Show Business Addresses Command.
		private ICommand showBusinessAddressesCommand;
		public ICommand ShowBusinessAddressesCommand
		{
			get => showBusinessAddressesCommand ?? (showBusinessAddressesCommand = new Command(async () => await ExecuteShowBusinessAddressesCommand()));
		}
		private async Task ExecuteShowBusinessAddressesCommand()
		{
			IsPersonalOrBusiness = false;
			BtnPersonalBg = "#2A2A31";
			BtnBusinessBg = "#0F9D58";
			foreach (var personalAddresses in CopyInvoiceAddress)
			{
				personalAddresses.IsPersonal = false;
				if (!personalAddresses.IsUser)
					personalAddresses.IsBusiness = true;
				else
					personalAddresses.IsBusiness = false;
			}
			ListOfInvoiceAddress = new ObservableCollection<Models.InvoiceAddressResponse>(CopyInvoiceAddress);
			await Task.CompletedTask;
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async () => await ExecuteSearchCommand()));
		}
		private async Task ExecuteSearchCommand()
		{
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string text = SearchText.ToLower();
				if (CopyInvoiceAddress?.Count > 0)
				{
					List<Models.InvoiceAddressResponse> addresses = null;
					if (IsPersonalOrBusiness)
						addresses = CopyInvoiceAddress.Where(x => x.AddressForSearch.ToLower().Contains(text) && x.IsPersonal == true).ToList();
					else
						addresses = CopyInvoiceAddress.Where(x => x.AddressForSearch.ToLower().Contains(text) && x.IsBusiness == true).ToList();
					ListOfInvoiceAddress = new ObservableCollection<Models.InvoiceAddressResponse>(addresses);
				}
			}
			else
			{
				if (IsPersonalOrBusiness)
					ShowPersonalAddressesCommand.Execute(null);
				else
					ShowBusinessAddressesCommand.Execute(null);
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Selected Paying Command.
		private ICommand selectedPayingCommand;
		public ICommand SelectedPayingCommand
		{
			get => selectedPayingCommand ?? (selectedPayingCommand = new Command(async () => await ExecuteSelectedPayingCommand()));
		}
		private async Task ExecuteSelectedPayingCommand()
		{
			Helper.Helper.CompanyId = InvoiceAddressDetail.CompanyId;
			Helper.Helper.InvoiceAddressDetail = InvoiceAddressDetail;
			//await Navigation.PushAsync(new Views.ReadOnlyInvoicingAddressPage());
			await Navigation.PushAsync(new Views.FinalStepToPayPage());
		}
		#endregion

		#region Invoice Address Detail Command.
		private ICommand invoiceAddressDetailCommand;
		public ICommand InvoiceAddressDetailCommand
		{
			get => invoiceAddressDetailCommand ?? (invoiceAddressDetailCommand = new Command(async () => await ExecuteInvoiceAddressDetailCommand()));
		}
		private async Task ExecuteInvoiceAddressDetailCommand()
		{
			InvoiceAddressDetail = InvoiceAddressList.FirstOrDefault(x => x.Id == InvoiceAddressId);
			IsVisibleInvoiceAddressDetail = true;
			await Task.CompletedTask;
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command( () =>  ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage.Navigation.PushAsync(new Views.ReadOnlyDeliveryAddressPage());
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.InvoiceAddressResponse> listOfInvoiceAddress;
		public ObservableCollection<Models.InvoiceAddressResponse> ListOfInvoiceAddress
		{
			get { return listOfInvoiceAddress; }
			set
			{
				listOfInvoiceAddress = value;
				OnPropertyChanged("ListOfInvoiceAddress");
			}
		}
		public List<Models.InvoiceAddressResponse> CopyInvoiceAddress { get; set; }


		private List<Models.InvoiceAddressResponse> invoiceAddressList;
		public List<Models.InvoiceAddressResponse> InvoiceAddressList
		{
			get => invoiceAddressList;
			set
			{
				invoiceAddressList = value;
				OnPropertyChanged("InvoiceAddressList");
			}
		}

		private Models.InvoiceAddressResponse invoiceAddressDetail;
		public Models.InvoiceAddressResponse InvoiceAddressDetail
		{
			get => invoiceAddressDetail;
			set
			{
				invoiceAddressDetail = value;
				OnPropertyChanged("InvoiceAddressDetail");
			}
		}

		private bool isVisibleInvoiceAddressDetail = false;
		public bool IsVisibleInvoiceAddressDetail
		{
			get => isVisibleInvoiceAddressDetail;
			set
			{
				isVisibleInvoiceAddressDetail = value;
				OnPropertyChanged("IsVisibleInvoiceAddressDetail");
			}
		}

		private bool isSingleInvoiceAddressDetail = true;
		public bool IsSingleInvoiceAddressDetail
		{
			get => isSingleInvoiceAddressDetail;
			set
			{
				isSingleInvoiceAddressDetail = value;
				OnPropertyChanged("IsSingleInvoiceAddressDetail");
			}
		}

		private bool isSubmit;
		public bool IsSubmit
		{
			get { return isSubmit; }
			set
			{
				isSubmit = value;
				OnPropertyChanged("IsSubmit");
			}
		}

		private string btnPersonalBg = "#0F9D58";
		public string BtnPersonalBg
		{
			get { return btnPersonalBg; }
			set
			{
				btnPersonalBg = value;
				OnPropertyChanged("BtnPersonalBg");
			}
		}

		private string btnBusinessBg = "#2A2A31";
		public string BtnBusinessBg
		{
			get { return btnBusinessBg; }
			set
			{
				btnBusinessBg = value;
				OnPropertyChanged("BtnBusinessBg");
			}
		}

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}

		public bool IsPersonalOrBusiness { get; set; } = true;
		public int InvoiceAddressId { get; set; }
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		public string StreetAndNr => "Street & nr";
		#endregion
	}
}
