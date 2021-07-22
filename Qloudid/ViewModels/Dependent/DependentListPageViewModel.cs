using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class DependentListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get All Dependent Command.
		private ICommand getAllDependentCommand;
		public ICommand GetAllDependentCommand
		{
			get => getAllDependentCommand ?? (getAllDependentCommand = new Command(async () => await ExecuteGetAllDependentCommand()));
		}
		private async Task ExecuteGetAllDependentCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDependentService service = new DependentService();
			DependentList = await service.GetAllDependentAsync(new Models.DependentRequest()
			{
				UserId = Helper.Helper.UserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add New Dependent Command.
		private ICommand addNewDependentCommand;
		public ICommand AddNewDependentCommand
		{
			get => addNewDependentCommand ?? (addNewDependentCommand = new Command(async () => await ExecuteAddNewDependentCommand()));
		}
		private async Task ExecuteAddNewDependentCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Dependent.AddNewDependentPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private List<Models.DependentResponse> dependentList;
		public List<Models.DependentResponse> DependentList
		{
			get => dependentList;
			set
			{
				dependentList = value;
				OnPropertyChanged("DependentList");
			}
		}
		#endregion
	}
}
