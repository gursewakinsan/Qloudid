using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class MyCountriesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public MyCountriesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Command.
		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get => submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand()));
		}
		private async Task ExecuteSubmitCommand()
		{
			if (string.IsNullOrWhiteSpace(MobileNumber))
				await Helper.Alert.DisplayAlert("Mobile number is required.");
			else if (MobileNumber.StartsWith("0"))
				await Helper.Alert.DisplayAlert("First digit cannot be zero.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IMyCountriesService service = new MyCountriesService();
				int response = await service.CheckMobileNumberAsync(new Models.CheckMobileNumberRequest()
				{
					CountryId = 67,
					UserId = Helper.Helper.UserId,
					PhoneNumber = MobileNumber
				});
				if (response == 0)
					await Helper.Alert.DisplayAlert("Mobile number already in use.");
				else if (response == 2)
					await Helper.Alert.DisplayAlert("Please enter a valid mobile number.");
				else if (response == 1)
				{
					Helper.Helper.UserMobileNumber = MobileNumber;
					await Navigation.PushAsync(new Views.MyCountries.VerifyPhonePinPage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public string MobileNumber { get; set; }
		public string CountryCode => $"+67";
		#endregion
	}
}
