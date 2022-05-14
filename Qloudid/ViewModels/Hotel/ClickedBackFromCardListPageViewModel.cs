using Xamarin.Forms;
using System.Windows.Input;

namespace Qloudid.ViewModels
{
	public class ClickedBackFromCardListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ClickedBackFromCardListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Go To Card List Page Command.
		private ICommand goToCardListPageCommand;
		public ICommand GoToCardListPageCommand
		{
			get => goToCardListPageCommand ?? (goToCardListPageCommand = new Command(() => ExecuteGoToCardListPageCommand()));
		}
		private void ExecuteGoToCardListPageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelCardListToPayPage());
		}
		#endregion

		#region Edit Invoice Address Command.
		private ICommand editInvoiceAddressCommand;
		public ICommand EditInvoiceAddressCommand
		{
			get => editInvoiceAddressCommand ?? (editInvoiceAddressCommand = new Command(() => ExecuteEditInvoiceAddressCommand()));
		}
		private void ExecuteEditInvoiceAddressCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelInvoiceAddressListPage());
		}
		#endregion

		#region Properties.
		public Models.InvoiceAddressResponse InvoiceAddress => Helper.Helper.InvoiceAddressDetail;
		#endregion
	}
}