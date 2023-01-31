using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class CompleteSignUpPageViewModel : BaseViewModel
    {
		#region Constructor.
		public CompleteSignUpPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			UserInfo = Helper.Helper.UserInfo;
		}
		#endregion

		#region Skip Command.
		private ICommand skipCommand;
		public ICommand SkipCommand
		{
			get => skipCommand ?? (skipCommand = new Command( () => ExecuteSkipCommand()));
		}
		private void ExecuteSkipCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
		}
		#endregion

		#region Pay Command.
		private ICommand payCommand;
		public ICommand PayCommand
		{
			get => payCommand ?? (payCommand = new Command(async () => await ExecutePayCommand()));
		}
		private async Task ExecutePayCommand()
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

		#region Passport Command.
		private ICommand passportCommand;
		public ICommand PassportCommand
		{
			get => passportCommand ?? (passportCommand = new Command(async () => await ExecutePassportCommand()));
		}
		private async Task ExecutePassportCommand()
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

		#region Start Command.
		private ICommand startCommand;
		public ICommand StartCommand
		{
			get => startCommand ?? (startCommand = new Command(() => ExecuteStartCommand()));
		}
		private void ExecuteStartCommand()
		{
			if (!UserInfo.CardCount)
				PayCommand.Execute(null);
			else if (!UserInfo.PassportCount)
				PassportCommand.Execute(null);
		}
		#endregion

		#region Properties.
		private Models.User userInfo;
		public Models.User UserInfo
		{
			get => userInfo;
			set
			{
				userInfo = value;
				OnPropertyChanged("UserInfo");
			}
		}
        #endregion
    }
}
