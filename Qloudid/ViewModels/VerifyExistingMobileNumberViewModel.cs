using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class VerifyExistingMobileNumberViewModel : BaseViewModel
	{
		#region Constructor.
		public VerifyExistingMobileNumberViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Yes Mobile Number Command.
		private ICommand yesMobileNumberCommand;
		public ICommand YesMobileNumberCommand
		{
			get => yesMobileNumberCommand ?? (yesMobileNumberCommand = new Command(async () => await ExecuteYesMobileNumberCommand()));
		}
		private async Task ExecuteYesMobileNumberCommand()
		{
			if (Helper.Helper.VerifyRestoreOtpPinWithMobileResult== 2)
				Application.Current.MainPage = new NavigationPage(new Views.IdentificatorPage());
			else if (Helper.Helper.VerifyRestoreOtpPinWithMobileResult == 3)
				Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
			await Task.CompletedTask;
		}
		#endregion

		#region No Mobile Number Command.
		private ICommand noMobileNumberCommand;
		public ICommand NoMobileNumberCommand
		{
			get => noMobileNumberCommand ?? (noMobileNumberCommand = new Command(async () => await ExecuteNoMobileNumberCommand()));
		}
		private async Task ExecuteNoMobileNumberCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.MobileNumberPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public string MobileNumber => Helper.Helper.UserMobileNumber;
		public string CountryCode => $"+{Helper.Helper.CountryCode}";
		#endregion
	}
}
