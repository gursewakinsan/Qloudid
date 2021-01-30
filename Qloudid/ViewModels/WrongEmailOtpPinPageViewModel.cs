using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WrongEmailOtpPinPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WrongEmailOtpPinPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Resend Otp Pin On Email Command.
		private ICommand resendOtpPinOnEmailCommand;
		public ICommand ResendOtpPinOnEmailCommand
		{
			get => resendOtpPinOnEmailCommand ?? (resendOtpPinOnEmailCommand = new Command(async () => await ExecuteResendOtpPinOnEmailCommand()));
		}
		private async Task ExecuteResendOtpPinOnEmailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAccountRestoreService service = new AccountRestoreService();
			Models.RestoreAccountRequest request = new Models.RestoreAccountRequest()
			{
				Email = Helper.Helper.UserEmail
			};
			Models.RestoreAccountResponse response = await service.RestoreAccountAsync(request);
			if (response == null)
				await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
			else if (response.result == 1)
			{
				Helper.Helper.UserId = response.user_id;
				await Navigation.PopAsync();
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Try Again Command.
		private ICommand tryAgainCommand;
		public ICommand TryAgainCommand
		{
			get => tryAgainCommand ?? (tryAgainCommand = new Command(async () => await ExecuteTryAgainCommand()));
		}
		private async Task ExecuteTryAgainCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion
	}
}
