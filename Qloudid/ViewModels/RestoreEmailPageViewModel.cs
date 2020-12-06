using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class RestoreEmailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RestoreEmailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Restore Email Command.
		private ICommand submitRestoreEmailCommand;
		public ICommand SubmitRestoreEmailCommand
		{
			get => submitRestoreEmailCommand ?? (submitRestoreEmailCommand = new Command(async () => await ExecuteSubmitRestoreEmailCommand()));
		}
		private async Task ExecuteSubmitRestoreEmailCommand()
		{
			if (string.IsNullOrWhiteSpace(Email))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(Email))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				await Navigation.PushAsync(new Views.RestoreEmailPasswordPage());
			}
		}
		#endregion

		#region Properties.
		public string Email { get; set; }
		#endregion
	}
}
