using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

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
			IsVisibleInvoiceAddressDetail = false;
			InvoiceAddressList = await service.GetInvoiceAddressAsync(new Models.InvoiceAddressRequest() { UserId = Helper.Helper.UserId });
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

		#region Properties.
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
		public int InvoiceAddressId { get; set; }
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;

		#endregion
	}
}
