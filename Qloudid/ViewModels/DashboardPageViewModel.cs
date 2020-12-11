using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class DashboardPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DashboardPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			UserInfo = Helper.Helper.UserInfo;
		}
		#endregion

		#region Login To Desktop Command.
		private ICommand loginToDesktopCommand;
		public ICommand LoginToDesktopCommand
		{
			get => loginToDesktopCommand ?? (loginToDesktopCommand = new Command<string>(async (qrCode) => await ExecuteLoginToDesktopCommand(qrCode)));
		}
		private async Task ExecuteLoginToDesktopCommand(string qrCode)
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey, new Models.UpdateLoginIP() { ip = qrCode });
			if (response == 1)
				await Navigation.PushAsync(new Views.VerifyPasswordPage());
			else if (response == 2)
				await Navigation.PushAsync(new Views.InvalidQrCodePage());
			else if (response == 3)
				await Navigation.PushAsync(new Views.UserUnauthorizedPage());
			else
				await Navigation.PushAsync(new Views.UserAlertPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Login From Url Ip Command.
		private ICommand loginFromUrlIpCommand;
		public ICommand LoginFromUrlIpCommand
		{
			get => loginFromUrlIpCommand ?? (loginFromUrlIpCommand = new Command(async () => await ExecuteLoginFromUrlIpCommand()));
		}
		private async Task ExecuteLoginFromUrlIpCommand()
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
				ILoginService service = new LoginService();
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response.result > 0)
				{
					Models.User user = new Models.User();
					user.first_name = Application.Current.Properties["FirstName"].ToString();
					user.last_name = Application.Current.Properties["LastName"].ToString();
					user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
					user.UserImage = response.image;
					Helper.Helper.UserInfo = user;
					LoginToDesktopCommand.Execute(Helper.Helper.IpFromURL);
				}
				else
					await Navigation.PushAsync(new Views.InvalidCertificatePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public Models.User UserInfo { get; set; }
		//public string UserImage => Helper.Helper.UserInfo.UserImage; //$"https://www.qloudid.com/estorecss/tmp.jpg";
		public string AppVersion => Xamarin.Essentials.VersionTracking.CurrentVersion;
		public bool IsUserImage => string.IsNullOrEmpty(UserInfo.UserImage) ? false : true;
		public bool IsAppLogo => string.IsNullOrEmpty(UserInfo.UserImage) ? true : false;
		#endregion
	}
}
