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
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.VerifyUserMobileRequest request = new Models.VerifyUserMobileRequest()
				{
					UserId = Helper.Helper.UserId,
					MobileNo = MobileNumber
				};
				var response = await service.VerifyUserMobileAsync(request);
				DependencyService.Get<IProgressBar>().Hide();
				await Navigation.PushAsync(new Views.SignaturePinPage());
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
