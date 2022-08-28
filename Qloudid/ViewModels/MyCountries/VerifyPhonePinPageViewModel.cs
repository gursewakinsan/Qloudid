using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class VerifyPhonePinPageViewModel : BaseViewModel
    {
		#region Constructor.
		public VerifyPhonePinPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Otp Command.
		private ICommand submitOtpCommand;
		public ICommand SubmitOtpCommand
		{
			get => submitOtpCommand ?? (submitOtpCommand = new Command(async () => await ExecuteSubmitOtpCommand()));
		}
		private async Task ExecuteSubmitOtpCommand()
		{
			if (string.IsNullOrWhiteSpace(Password))
				await Helper.Alert.DisplayAlert("Code is required.");
			else
			{
				if (Password.Length < 4) return;
				DependencyService.Get<IProgressBar>().Show();
				IMyCountriesService service = new MyCountriesService();
				int response = await service.VerifyOtpDetailAsync(new Models.VerifyOtpDetailRequest()
				{
					UserId = Helper.Helper.UserId,
					Otp = Password
				});
				if (response == 0)
					await Helper.Alert.DisplayAlert("Wrong otp.");
				else
					await Navigation.PushAsync(new Views.MyCountries.AddVisitingCountryPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string Password { get; set; } = string.Empty;
		#endregion
	}
}
