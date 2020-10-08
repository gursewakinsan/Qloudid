using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WrongVerifyPasswordViewModel : BaseViewModel
	{
		#region Constructor.
		public WrongVerifyPasswordViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Update Login Status Command.
		private ICommand updateLoginStatusCommand;
		public ICommand UpdateLoginStatusCommand
		{
			get => updateLoginStatusCommand ?? (updateLoginStatusCommand = new Command(async () => await ExecuteUpdateLoginStatusCommand()));
		}
		private async Task ExecuteUpdateLoginStatusCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			int response = await service.UpdateLoginStatusAsync(Helper.Helper.QrCertificateKey);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
