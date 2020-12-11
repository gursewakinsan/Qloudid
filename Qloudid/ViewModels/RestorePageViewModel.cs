using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class RestorePageViewModel : BaseViewModel
	{
		#region Constructor.
		public RestorePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region New User Command.
		private ICommand newUserCommand;
		public ICommand NewUserCommand
		{
			get => newUserCommand ?? (newUserCommand = new Command(async () => await ExecuteNewUserCommand()));
		}
		private async Task ExecuteNewUserCommand()
		{
			await Navigation.PushAsync(new Views.CreateAccountPage());
		}
		#endregion

		#region User Restore Command.
		private ICommand userRestoreCommand;
		public ICommand UserRestoreCommand
		{
			get => userRestoreCommand ?? (userRestoreCommand = new Command(async () => await ExecuteUserRestoreCommand()));
		}
		private async Task ExecuteUserRestoreCommand()
		{
			await Navigation.PushAsync(new Views.RestoreEmailPage());
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
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response?.result > 0)
				{
					Models.User user = new Models.User();
					user.first_name = Application.Current.Properties["FirstName"].ToString();
					user.last_name = Application.Current.Properties["LastName"].ToString();
					user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
					user.email = Application.Current.Properties["Email"].ToString();
					user.UserImage = response.image;
					Helper.Helper.UserInfo = user;
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				}
				else
					await Navigation.PushAsync(new Views.InvalidCertificatePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion
	}
}
