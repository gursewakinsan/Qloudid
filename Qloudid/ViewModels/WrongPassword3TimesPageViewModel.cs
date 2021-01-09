using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WrongPassword3TimesPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WrongPassword3TimesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Continue Restore Command.
		private ICommand continueRestoreCommand;
		public ICommand ContinueRestoreCommand
		{
			get => continueRestoreCommand ?? (continueRestoreCommand = new Command(async () => await ExecuteContinueRestoreCommand()));
		}
		private async Task ExecuteContinueRestoreCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			Models.ClearCertificateRequest request = new Models.ClearCertificateRequest()
			{
				certi = Helper.Helper.QrCertificateKey
			};
			int response = await service.ClearCertificateAsync(request);
			Application.Current.Properties.Clear();
			Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
