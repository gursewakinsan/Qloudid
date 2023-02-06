using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AppStorePageViewModel : BaseViewModel
    {
		#region Constructor.
		public AppStorePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Children Command.
		private ICommand childrenCommand;
		public ICommand ChildrenCommand
		{
			get => childrenCommand ?? (childrenCommand = new Command(async () => await ExecuteChildrenCommand()));
		}
		private async Task ExecuteChildrenCommand()
		{
			//await Navigation.PushAsync(new Views.Dependent.DependentListPage());
			Helper.Helper.CountryOrChildren = "Children";
			await Navigation.PushAsync(new Views.MyCountries.ChangeProfilePage());
		}
		#endregion

		#region Manage Card Command.
		private ICommand manageCardCommand;
		public ICommand ManageCardCommand
		{
			get => manageCardCommand ?? (manageCardCommand = new Command(async () => await ExecuteManageCardCommand()));
		}
		private async Task ExecuteManageCardCommand()
		{
			await Navigation.PushAsync(new Views.CardListPage());
		}
		#endregion

		#region Go To My Home Page Command.
		private ICommand goToMyHomePageCommand;
		public ICommand GoToMyHomePageCommand
		{
			get => goToMyHomePageCommand ?? (goToMyHomePageCommand = new Command(async () => await ExecuteGoToMyHomePageCommand()));
		}
		private async Task ExecuteGoToMyHomePageCommand()
		{
			if (!Helper.Helper.IsPropertyStarted)
				await Navigation.PushAsync(new Views.Bedroom.GetStartedPropertyPage());
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IBedroomService service = new BedroomService();
				var responses = await service.UserDeliveryAddressesAsync(new Models.UserDeliveryAddressesRequest()
				{
					UserId = Helper.Helper.UserId
				});
				if (responses?.Count > 0)
					await Navigation.PushAsync(new Views.Bedroom.MyHomePage());
				else
					await Navigation.PushAsync(new Views.Bedroom.AddCreateYourPropertyPage());
				DependencyService.Get<IProgressBar>().Hide();
				
			}
		}
		#endregion
	}
}
