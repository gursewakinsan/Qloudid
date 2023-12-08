using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ExpressCheckInOutPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ExpressCheckInOutPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Started Command.
		private ICommand getStartedCommand;
		public ICommand GetStartedCommand
		{
			get => getStartedCommand ?? (getStartedCommand = new Command(() => ExecuteGetStartedCommand()));
		}
		private void ExecuteGetStartedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.CreateAccountPage());
		}
		#endregion
	}
}
