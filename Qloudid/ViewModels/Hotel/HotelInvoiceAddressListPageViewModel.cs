using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class HotelInvoiceAddressListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelInvoiceAddressListPageViewModel(INavigation navigation)
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
			var list = new List<Models.InvoiceAddressInfo>();
			if (response?.Count > 0)
			{
				int index = 0;
				Models.InvoiceAddressInfo listPersonal = new Models.InvoiceAddressInfo();
				Models.InvoiceAddressInfo listCompanies = new Models.InvoiceAddressInfo();
				foreach (var item in response)
				{
					if (item.IsUser)
					{
						item.FirstLetterNameBg = Helper.Helper.ColorList[index];
						listPersonal.Add(item);
					}
					else
					{
						item.FirstLetterNameBg = Helper.Helper.ColorList[index];
						listCompanies.Add(item);
					}
					index = index + 1;
				}

				if (listPersonal.Count > 0)
				{
					listPersonal.Heading = "Personal";
					list.Add(listPersonal);
				}
				if (listCompanies.Count > 0)
				{
					listCompanies.Heading = "Companies";
					list.Add(listCompanies);
				}
			}
			ListOfInvoiceAddress = list;
			DependencyService.Get<IProgressBar>().Hide();
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
			await Navigation.PushAsync(new Views.Hotel.HotelReadOnlyInvoicingAddressPage());
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

		#region Properties.
		private List<Models.InvoiceAddressInfo> listOfInvoiceAddress;
		public List<Models.InvoiceAddressInfo> ListOfInvoiceAddress
		{
			get { return listOfInvoiceAddress; }
			set
			{
				listOfInvoiceAddress = value;
				OnPropertyChanged("ListOfInvoiceAddress");
			}
		}

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
		public int InvoiceAddressId { get; set; }
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		public string StreetAndNr => "Street & nr";
		#endregion
	}
}
