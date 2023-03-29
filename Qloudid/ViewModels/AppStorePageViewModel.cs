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

        #region Add Identity card Command.
        private ICommand addIdentityCardCommand;
        public ICommand AddIdentityCardCommand
        {
            get => addIdentityCardCommand ?? (addIdentityCardCommand = new Command(async () => await ExecuteAddIdentityCardCommand()));
        }
        private async Task ExecuteAddIdentityCardCommand()
        {
			DependencyService.Get<IProgressBar>().Show();
			IIdentityService service = new IdentityService();
			var responses = await service.IdentificatorCountDetailAsync(new Models.IdentificatorCountDetailRequest()
			{
				UserId = Helper.Helper.UserId
			});
			Helper.Helper.IdentificatorCountDetail = responses;
			if (responses.TotalCount == 0)
				await Navigation.PushAsync(new Views.Identity.NoIdentityCardAddedPage());
			else
				await Navigation.PushAsync(new Views.Identity.IdentityCardListPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Pre Check In Command.
		private ICommand preCheckInCommand;
		public ICommand PreCheckInCommand
		{
			get => preCheckInCommand ?? (preCheckInCommand = new Command(async () => await ExecutePreCheckInCommand()));
		}
		private async Task ExecutePreCheckInCommand()
		{
			await Navigation.PushAsync(new Views.Booking.ManagePreCheckinReservationPage());
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
			Application.Current.MainPage.Navigation.PushAsync(new Views.DashboardPage());
		}
		#endregion
	}
}
