using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class GetStartedPropertyPageViewModel : BaseViewModel
    {
		#region Constructor.
		public GetStartedPropertyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Update Property Start Command.
		private ICommand updatePropertyStartCommand;
		public ICommand UpdatePropertyStartCommand
		{
			get => updatePropertyStartCommand ?? (updatePropertyStartCommand = new Command(async () => await ExecuteUpdatePropertyStartCommand()));
		}
		private async Task ExecuteUpdatePropertyStartCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.UpdatePropertyStartAsync(new Models.UpdatePropertyStartRequest()
			{
				UserId = Helper.Helper.UserId
			});
			DependencyService.Get<IProgressBar>().Hide();
			await Navigation.PushAsync(new Views.Bedroom.MyHomePage());
		}
		#endregion
	}
}
