using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class ReadOnlyDeliveryAddressPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ReadOnlyDeliveryAddressPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected Delivery Address Command.
		private ICommand selectedDeliveryAddressCommand;
		public ICommand SelectedDeliveryAddressCommand
		{
			get => selectedDeliveryAddressCommand ?? (selectedDeliveryAddressCommand = new Command(async () => await ExecuteSelectedDeliveryAddressCommand()));
		}
		private async Task ExecuteSelectedDeliveryAddressCommand()
		{
			await Navigation.PushAsync(new Views.WhoIsPayingPage());
		}
		#endregion

		#region Properties.
		public Models.DeliveryAddressDetailResponse DisplayDeliveryAddress => Helper.Helper.DeliveryAddressDetail;
		#endregion
	}
}
