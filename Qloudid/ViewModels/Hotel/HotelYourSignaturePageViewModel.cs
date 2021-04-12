using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class HotelYourSignaturePageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelYourSignaturePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Confirm And Sign Command.
		private ICommand confirmAndSignCommand;
		public ICommand ConfirmAndSignCommand
		{
			get => confirmAndSignCommand ?? (confirmAndSignCommand = new Command(async () => await ExecuteConfirmAndSignCommand()));
		}
		private async Task ExecuteConfirmAndSignCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.ConfirmAndSignSignaturePage());
			await Task.CompletedTask;
		}
		#endregion

		#region Cancel Confirm And Sign Command.
		private ICommand cancelConfirmAndSignCommand;
		public ICommand CancelConfirmAndSignCommand
		{
			get => cancelConfirmAndSignCommand ?? (cancelConfirmAndSignCommand = new Command(async () => await ExecuteCancelConfirmAndSignCommand()));
		}
		private async Task ExecuteCancelConfirmAndSignCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Edit Invoicing Address Command.
		private ICommand editInvoicingAddressCommand;
		public ICommand EditInvoicingAddressCommand
		{
			get => editInvoicingAddressCommand ?? (editInvoicingAddressCommand = new Command(async () => await ExecuteEditInvoicingAddressCommand()));
		}
		private async Task ExecuteEditInvoicingAddressCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelInvoiceAddressListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Edit Card Detail Command.
		private ICommand editCardDetailCommand;
		public ICommand EditCardDetailCommand
		{
			get => editCardDetailCommand ?? (editCardDetailCommand = new Command(async () => await ExecuteEditCardDetailCommand()));
		}
		private async Task ExecuteEditCardDetailCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		public Models.BookingDetailResponse HotelBookingDetail => Helper.Helper.HotelBookingDetail;
		public Models.InvoiceAddressResponse InvoiceAddress => Helper.Helper.InvoiceAddressDetail;
		public Models.CardDetailResponse CardDetail => Helper.Helper.CardDetail;
		#endregion
	}
}
