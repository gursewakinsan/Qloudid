using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class MyHomePageViewModel : BaseViewModel
    {
		#region Constructor.
		public MyHomePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Bedroom Detail Command.
		private ICommand bedroomDetailCommand;
		public ICommand BedroomDetailCommand
		{
			get => bedroomDetailCommand ?? (bedroomDetailCommand = new Command(async () => await ExecuteBedroomDetailCommand()));
		}
		private async Task ExecuteBedroomDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			UserDeliveryAddresses = await service.UserDeliveryAddressesAsync(new Models.UserDeliveryAddressesRequest()
			{
				UserId = Helper.Helper.UserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.UserDeliveryAddressesResponse> userDeliveryAddresses;
		public List<Models.UserDeliveryAddressesResponse> UserDeliveryAddresses
		{
			get => userDeliveryAddresses;
			set
			{
				userDeliveryAddresses = value;
				OnPropertyChanged("UserDeliveryAddresses");
			}
		}
		#endregion
	}
}
