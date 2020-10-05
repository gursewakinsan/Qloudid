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
			Helper.Helper.QrCertificateKey = id;
			ILoginService service = new LoginService();
			int response = await service.LoginAsync(id);
			if (response > 0)
			{
				Application.Current.MainPage = new NavigationPage(new Views.CheckPasswordPage());
				//Go to passwor pag & call api 
				//https://www.qloudid.com/user/index.php/QloudidApp/checkPassword/{tokn}
				//[password=>123456]

				//rsult - o - wrong pass
				// rsult - 1 - gt pass
			}
			else
				await Helper.Alert.DisplayAlert("This QR code is invalid.");
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
