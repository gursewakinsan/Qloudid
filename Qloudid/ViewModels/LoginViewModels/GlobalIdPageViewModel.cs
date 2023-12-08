using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class GlobalIdPageViewModel : BaseViewModel
    {
		#region Constructor.
		public GlobalIdPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Next Command.
		private ICommand nextCommand;
		public ICommand NextCommand
		{
			get => nextCommand ?? (nextCommand = new Command(async () => await ExecuteNextCommand()));
		}
		private async Task ExecuteNextCommand()
		{
			await Navigation.PushAsync(new Views.LoginPages.PaymentOnlinePage());
		}
		#endregion

		#region Skip Command.
		private ICommand skipCommand;
		public ICommand SkipCommand
		{
			get => skipCommand ?? (skipCommand = new Command( () =>  ExecuteSkipCommand()));
		}
		private void ExecuteSkipCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.CreateAccountPage());
		}
		#endregion
	}
}
