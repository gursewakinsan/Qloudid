using Xamarin.Forms;
using System.Windows.Input;

namespace Qloudid.ViewModels
{
	public class ClickedBackFromDeliveryAddressPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ClickedBackFromDeliveryAddressPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Go To Invoice Address List Page Command.
		private ICommand goToInvoiceAddressListPageCommand;
		public ICommand GoToInvoiceAddressListPageCommand
		{
			get => goToInvoiceAddressListPageCommand ?? (goToInvoiceAddressListPageCommand = new Command(() => ExecuteGoToInvoiceAddressListPageCommand()));
		}
		private void ExecuteGoToInvoiceAddressListPageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelInvoiceAddressListPage());
		}
		#endregion
	}
}
