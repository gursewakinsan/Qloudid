using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class RestoreEmailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RestoreEmailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Restore Email Command.
		private ICommand submitRestoreEmailCommand;
		public ICommand SubmitRestoreEmailCommand
		{
			get => submitRestoreEmailCommand ?? (submitRestoreEmailCommand = new Command(async () => await ExecuteSubmitRestoreEmailCommand()));
		}
		private async Task ExecuteSubmitRestoreEmailCommand()
		{
			if (string.IsNullOrWhiteSpace(Email))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(Email))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IAccountRestoreService service = new AccountRestoreService();
				Models.RestoreAccountRequest request = new Models.RestoreAccountRequest()
				{
					Email = Email
				};
				Models.RestoreAccountResponse response = await service.RestoreAccountAsync(request);
				if (response == null)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response.result == 0)
					Application.Current.MainPage = new NavigationPage(new Views.AccountNotAvailablePage());
				else if (response.result == 1)
				{
					Helper.Helper.UserId = response.user_id;
					Helper.Helper.UserEmail = Email;
					await Navigation.PushAsync(new Views.RestoreEmailPasswordPage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command( () =>  ExecuteBackButtonControlCommand()));
		}
		private void ExecuteBackButtonControlCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
		}
		#endregion

		#region Properties.
		public string Email { get; set; } // = "deservingchandan@gmail.com";
		#endregion
	}
}
