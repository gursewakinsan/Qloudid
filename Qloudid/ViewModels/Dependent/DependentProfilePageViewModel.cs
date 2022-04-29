using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class DependentProfilePageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentProfilePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Edit Dependent Command.
		private ICommand editDependentCommand;
		public ICommand EditDependentCommand
		{
			get => editDependentCommand ?? (editDependentCommand = new Command(async () => await ExecuteEditDependentCommand()));
		}
		private async Task ExecuteEditDependentCommand()
		{
			await Navigation.PushAsync(new Views.Dependent.EditDependentPage());
		}
		#endregion

		#region Properties.
		public Models.DependentDetailResponse DependentDetail => Helper.Helper.DependentDetail;
		#endregion
	}
}
