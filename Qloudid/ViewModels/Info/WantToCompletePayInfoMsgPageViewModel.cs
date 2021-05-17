using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WantToCompletePayInfoMsgPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WantToCompletePayInfoMsgPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Continue Command.
		private ICommand continueCommand;
		public ICommand ContinueCommand
		{
			get => continueCommand ?? (continueCommand = new Command(async () => await ExecuteContinueCommand()));
		}
		private async Task ExecuteContinueCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAccountRestoreService service = new AccountRestoreService();
			await service.UpdatePayRequiredAsync(new Models.UpdatePayRequiredRequest()
			{
				Pay = 1,
				Certificate = Helper.Helper.QrCertificateKey
			});
			if (Helper.Helper.GenerateCertificateIdentificatorValue == 1)
				Application.Current.MainPage = new NavigationPage(new Views.AddNewCardPage());
			else if (Helper.Helper.GenerateCertificateIdentificatorValue == 2)
				Application.Current.MainPage = new NavigationPage(new Views.AddDeliveryAddressPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Cancel Command.
		private ICommand cancelCommand;
		public ICommand CancelCommand
		{
			get => cancelCommand ?? (cancelCommand = new Command(async() => await ExecuteCancelCommand()));
		}
		private async Task ExecuteCancelCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAccountRestoreService service = new AccountRestoreService();
			await service.UpdatePayRequiredAsync(new Models.UpdatePayRequiredRequest()
			{
				Pay = 2,
				Certificate = Helper.Helper.QrCertificateKey
			});
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
