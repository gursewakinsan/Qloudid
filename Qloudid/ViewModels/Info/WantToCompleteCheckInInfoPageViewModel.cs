using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WantToCompleteCheckInInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WantToCompleteCheckInInfoPageViewModel(INavigation navigation)
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
			await service.UpdateCheckRequiredAsync(new Models.UpdateCheckRequiredRequest()
			{
				Check = 1,
				Certificate = Helper.Helper.QrCertificateKey
			});
			if (Helper.Helper.GenerateCertificateIdentificatorValue == 0)
			{
				//Application.Current.MainPage = new NavigationPage(new Views.IdentificatorPage());
				Helper.Helper.SelectedIdentificatorText = "Passport";
				Application.Current.MainPage = new NavigationPage(new Views.SelectedIdentificatorPage());
			}
			else if (Helper.Helper.GenerateCertificateIdentificatorValue == -1)
			{
				var response = await service.IdentificatorDetailAsync(new Models.IdentificatorDetailRequest()
				{
					UserId = Helper.Helper.UserId
				});
				if (response?.Count == 2)
					Application.Current.MainPage = new NavigationPage(new Views.Info.IdentificatorPageForCheckIn());
				else
				{
					Helper.Helper.SelectedIdentificatorId = response[0].IdentificationType;
					Application.Current.MainPage = new NavigationPage(new Views.IdentificatorPhotoPage());
				}
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Cancel Command.
		private ICommand cancelCommand;
		public ICommand CancelCommand
		{
			get => cancelCommand ?? (cancelCommand = new Command(async () => await ExecuteCancelCommand()));
		}
		private async Task ExecuteCancelCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAccountRestoreService service = new AccountRestoreService();
			await service.UpdateCheckRequiredAsync(new Models.UpdateCheckRequiredRequest()
			{
				Check = 2,
				Certificate = Helper.Helper.QrCertificateKey
			});
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
