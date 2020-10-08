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
			else
				await Navigation.PushAsync(new Views.UserAlertPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public Models.User UserInfo { get; set; }
		#endregion
	}
}
