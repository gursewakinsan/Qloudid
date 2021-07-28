using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class DependentListForCheckInPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentListForCheckInPageViewModel(INavigation navigation)
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
			if (DependentList?.Count == 0)
				await Navigation.PushAsync(new Views.Dependent.EmptyDependentListPage());
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
			await Navigation.PopAsync();
		}
		#endregion

		#region Submit Selected Dependent Command.
		private ICommand submitSelectedDependentCommand;
		public ICommand SubmitSelectedDependentCommand
		{
			get => submitSelectedDependentCommand ?? (submitSelectedDependentCommand = new Command(async () => await ExecuteSubmitSelectedDependentCommand()));
		}
		private async Task ExecuteSubmitSelectedDependentCommand()
		{
			if (SelectedDependents?.Count > 0)
			{ 
			}
			else
				await Helper.Alert.DisplayAlert("Please select dependent for submit.");
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

		public List<int> SelectedDependents { get; set; }
		#endregion
	}
}
