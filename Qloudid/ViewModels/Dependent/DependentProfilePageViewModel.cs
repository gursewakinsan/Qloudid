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

		#region Add Edit Dependent Passport Command.
		private ICommand addEditDependentPassportCommand;
		public ICommand AddEditDependentPassportCommand
		{
			get => addEditDependentPassportCommand ?? (addEditDependentPassportCommand = new Command(async () => await ExecuteAddEditDependentPassportCommand()));
		}
		private async Task ExecuteAddEditDependentPassportCommand()
		{
			Helper.Helper.DependentId = DependentDetail.Id;
			if (DependentDetail.IsPassportUpdated)
				await Navigation.PushAsync(new Views.Dependent.EditUploadDependentPassportPhotoPage());
			else
				await Navigation.PushAsync(new Views.Dependent.UploadDependentPassportPhotoPage());
		}
		#endregion

		#region Properties.
		public Models.DependentDetailResponse DependentDetail => Helper.Helper.DependentDetail;
		#endregion
	}
}
