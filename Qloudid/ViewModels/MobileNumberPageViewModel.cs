using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class MobileNumberPageViewModel : BaseViewModel
	{
		#region Constructor.
		public MobileNumberPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Save Mobile Number Command.
		private ICommand saveMobileNumberCommand;
		public ICommand SaveMobileNumberCommand
		{
			get => saveMobileNumberCommand ?? (saveMobileNumberCommand = new Command(async () => await ExecuteSaveMobileNumberCommand()));
		}
		private async Task ExecuteSaveMobileNumberCommand()
		{
			if (string.IsNullOrWhiteSpace(MobileNumber))
				await Helper.Alert.DisplayAlert("Mobile number is required.");
			else if(MobileNumber.StartsWith("0"))
				await Helper.Alert.DisplayAlert("First digit cannot be zero.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.VerifyUserMobileRequest request = new Models.VerifyUserMobileRequest()
				{
					UserId = Helper.Helper.UserId,
					MobileNo = MobileNumber
				};
				Models.VerifyUserMobileResponse response = await service.VerifyUserMobileAsync(request);
				if (response == null)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response.result == 0)
					await Helper.Alert.DisplayAlert("This mobile number is already in used. Please use any other mobile number.");
				else if (response.result == 1)
				{
					Helper.Helper.UserMobileNumber = MobileNumber;
					await Navigation.PushAsync(new Views.SignaturePinPage());
				}
				if (response.result == 2)
					await Helper.Alert.DisplayAlert("Unable to send OTP on this mobile number, Please use correct mobile number.");
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public string MobileNumber { get; set; }
		public string CountryCode => $"+{Helper.Helper.CountryCode}";
		#endregion
	}
}
