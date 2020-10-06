using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		#region Constructor.
		public LoginViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Login Command.
		private ICommand loginCommand;
		public ICommand LoginCommand
		{
			get => loginCommand ?? (loginCommand = new Command<string>(async (id) => await ExecuteLoginCommand(id)));
		}
		private async Task ExecuteLoginCommand(string id)
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			int response = await service.LoginAsync(id);
			if (response > 0)
			{
				Helper.Helper.QrCertificateKey = id;
				if (Application.Current.Properties.ContainsKey("QrCode"))
					Application.Current.Properties.Remove("QrCode");
				Application.Current.Properties.Add("QrCode", id);
				await Application.Current.SavePropertiesAsync();

				Application.Current.MainPage = new NavigationPage(new Views.CheckPasswordPage());
			}
			else
				await Helper.Alert.DisplayAlert("This QR code is invalid.");
			DependencyService.Get<IProgressBar>().Hide();
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
			DependencyService.Get<IProgressBar>().Show();
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
				//Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			}
			else
			{ 
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		//public string Username { get; set; } //= "qloudsuperagent1@qloudid.com";
		//public string Password { get; set; } //= "av#ng3rs";
		public string Password { get; set; }
		#endregion
	}
}
