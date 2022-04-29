using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class DependentDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Dependent Profile Page Command.
		private ICommand dependentProfilePageCommand;
		public ICommand DependentProfilePageCommand
		{
			get => dependentProfilePageCommand ?? (dependentProfilePageCommand = new Command(async () => await ExecuteDependentProfilePageCommand()));
		}
		private async Task ExecuteDependentProfilePageCommand()
		{
			await Navigation.PushAsync(new Views.Dependent.DependentProfilePage());
		}
		#endregion

		#region Properties.
		public Models.DependentDetailResponse DependentDetail => Helper.Helper.DependentDetail;
		#endregion
	}
}
