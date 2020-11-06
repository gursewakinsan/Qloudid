using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
		#region Constructor.
		public HomePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Validate QR Code Command.
		private ICommand validateQrCodeCommand;
		public ICommand ValidateQrCodeCommand
		{
			get => validateQrCodeCommand ?? (validateQrCodeCommand = new Command<string>(async (qrCode) => await ExecuteValidateQrCodeCommand(qrCode)));
		}
		private async Task ExecuteValidateQrCodeCommand(string qrCode)
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			int response = await service.LoginAsync(qrCode);
			if (response > 0)
			{
				Helper.Helper.QrCertificateKey = qrCode;
				await Navigation.PushAsync(new Views.CheckPasswordPage());
			}
			else
				await Navigation.PushAsync(new Views.InvalidQrCodePage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Is Already Login Command.
		private ICommand isAlreadyLoginCommand;
		public ICommand IsAlreadyLoginCommand
		{
			get => isAlreadyLoginCommand ?? (isAlreadyLoginCommand = new Command(async () => await ExecuteIsAlreadyLoginCommand()));
		}
		private async Task ExecuteIsAlreadyLoginCommand()
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
				ILoginService service = new LoginService();
				int response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response > 0)
				{
					Models.User user = new Models.User();
					user.first_name = Application.Current.Properties["FirstName"].ToString();
					user.last_name = Application.Current.Properties["LastName"].ToString();
					user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
					user.email = Application.Current.Properties["Email"].ToString();
					Helper.Helper.UserInfo = user;
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				}
				else
					await Navigation.PushAsync(new Views.InvalidCertificatePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Scan QR Code Command.
		private ICommand scanQrCodeCommand;
		public ICommand ScanQrCodeCommand
		{
			get => scanQrCodeCommand ?? (scanQrCodeCommand = new Command(async () => await ExecuteScanQrCodeCommand()));
		}
		private async Task ExecuteScanQrCodeCommand()
		{
			await Navigation.PushAsync(new Views.HomeScannerPage());
		}
		#endregion
	}
}
