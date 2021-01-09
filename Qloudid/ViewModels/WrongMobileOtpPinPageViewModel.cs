using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WrongMobileOtpPinPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WrongMobileOtpPinPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Resend Otp Pin On Mobile Command.
		private ICommand resendOtpPinOnMobileCommand;
		public ICommand ResendOtpPinOnMobileCommand
		{
			get => resendOtpPinOnMobileCommand ?? (resendOtpPinOnMobileCommand = new Command(async () => await ExecuteResendOtpPinOnMobileCommand()));
		}
		private async Task ExecuteResendOtpPinOnMobileCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICreateAccountService service = new CreateAccountService();
			Models.VerifyUserMobileRequest request = new Models.VerifyUserMobileRequest()
			{
				UserId = Helper.Helper.UserId,
				MobileNo = Helper.Helper.UserMobileNumber
			};
			Models.VerifyUserMobileResponse response = await service.VerifyUserMobileAsync(request);
			if (response == null)
				await Helper.Alert.DisplayAlert("Somthing went wrong, Please try after some time.");
			else if (response.result == 0)
				await Helper.Alert.DisplayAlert("This mobile number is already in used. Please use any other mobile number.");
			else if (response.result == 1)
				await Navigation.PopAsync();
			if (response.result == 2)
				await Helper.Alert.DisplayAlert("Unable to send OTP on this mobile number, Please use correct mobile number.");
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
