using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class VerifyPasswordPageViewModel : BaseViewModel
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
			if (!string.IsNullOrWhiteSpace(Password))
			{
				Helper.Helper.IsBack = false;
				DependencyService.Get<IProgressBar>().Show();
				IDashboardService service = new DashboardService();
				int response = await service.VerifyPasswordAsync(Helper.Helper.QrCertificateKey, new SetPassword() { password = Password });
				Password = string.Empty;
				if (response == 1)
					Application.Current.MainPage = new NavigationPage(new Views.SuccessfulPage());
				else if (response == 2)
					Application.Current.MainPage = new NavigationPage(new Views.TimeOutPage());
				else if (response == 3)
					await Navigation.PushAsync(new Views.PurchasePage());
				else
					await Navigation.PushAsync(new Views.WrongVerifyPasswordPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				await Helper.Alert.DisplayAlert("Please enter password.");
		}
		#endregion

		#region Cancel Verify Password Command.
		private ICommand cancelVerifyPasswordCommand;
		public ICommand CancelVerifyPasswordCommand
		{
			get => cancelVerifyPasswordCommand ?? (cancelVerifyPasswordCommand = new Command(async () => await ExecuteCancelVerifyPasswordCommand()));
		}
		private async Task ExecuteCancelVerifyPasswordCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Clear Ips Command.
		private ICommand clearIpsCommand;
		public ICommand ClearIpsCommand
		{
			get => clearIpsCommand ?? (clearIpsCommand = new Command(async () => await ExecuteClearIpsCommand()));
		}
		private async Task ExecuteClearIpsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			int response = await service.ClearIpsAsync(Helper.Helper.QrCertificateKey);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public string Password { get; set; }
		#endregion
	}
}
