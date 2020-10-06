using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	class VerifyPasswordPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VerifyPasswordPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Verify Password Command.
		private ICommand verifyPasswordCommand;
		public ICommand VerifyPasswordCommand
		{
			get => verifyPasswordCommand ?? (verifyPasswordCommand = new Command(async () => await ExecuteVerifyPasswordCommand()));
		}
		private async Task ExecuteVerifyPasswordCommand()
		{
			if (string.IsNullOrWhiteSpace(Password))
				await Helper.Alert.DisplayAlert("Password is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IDashboardService service = new DashboardService();
				int response = await service.VerifyPasswordAsync(Helper.Helper.QrCertificateKey, new SetPassword() { password = Password });
				if (response > 0)
					await Helper.Alert.DisplayAlert("Login successfull ");
				else
					await Helper.Alert.DisplayAlert("Wrong Password");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string Password { get; set; }
		#endregion
	}
}
