using System.Linq;
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

		#region Add Property Command.
		private ICommand addPropertyCommand;
		public ICommand AddPropertyCommand
		{
			get => addPropertyCommand ?? (addPropertyCommand = new Command(async () => await ExecuteAddPropertyCommand()));
		}
		private async Task ExecuteAddPropertyCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.AddCreateYourPropertyPage());
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage.Navigation.PushAsync(new Views.AppStorePage());
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
