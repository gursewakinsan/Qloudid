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
				if (response != null)
				{
				}
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
