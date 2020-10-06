using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class CheckPasswordViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckPasswordViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Check Password Command.
		private ICommand checkPasswordCommand;
		public ICommand CheckPasswordCommand
		{
			get => checkPasswordCommand ?? (checkPasswordCommand = new Command(async () => await ExecuteCheckPasswordCommand()));
		}
		private async Task ExecuteCheckPasswordCommand()
		{
			if (string.IsNullOrWhiteSpace(Password))
				await Helper.Alert.DisplayAlert("Password is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ILoginService service = new LoginService();
				var response = await service.CheckPasswordAsync(Helper.Helper.QrCertificateKey, new SetPassword() { password = Password });
				if (response.result > 0)
				{
					Helper.Helper.UserInfo = response;
					if (Application.Current.Properties.Count > 0)
						Application.Current.Properties.Clear();

					Application.Current.Properties.Add("QrCode", Helper.Helper.QrCertificateKey);
					Application.Current.Properties.Add("FirstName", response.first_name);
					Application.Current.Properties.Add("LastName", response.last_name);
					Application.Current.Properties.Add("UserId", response.user_id);
					await Application.Current.SavePropertiesAsync();
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				}
				else
					await Helper.Alert.DisplayAlert("Wrong Password");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string Password { get; set; }
		#endregion
	}
}
public class SetPassword
{
	public string password { get; set; }
}
