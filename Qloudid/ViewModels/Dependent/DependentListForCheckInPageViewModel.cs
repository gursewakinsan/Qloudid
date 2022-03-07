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
			DependentList = await service.DependentsListForCheckInAsync(new Models.DependentsListForCheckInRequest()
			{
				UserId = Helper.Helper.UserId,
				Id = Helper.Helper.VerifyUserConsentClientId
			});

			GuestChildrenRemainingCount = await service.GuestChildrenRemainingCountAsync(new Models.GuestChildrenRemainingCountRequest()
			{
				CheckId = Helper.Helper.VerifyUserConsentClientId
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
				DependencyService.Get<IProgressBar>().Show();
				IDependentService service = new DependentService();
				int response = await service.UpdateDependentCheckinIdsAsync(new Models.UpdateDependentCheckinIdsRequest()
				{
					Certificate = Helper.Helper.QrCertificateKey,
					SelectedDependentIds = string.Join(",", SelectedDependents)
				});
				if (response == 1)
					Application.Current.MainPage = new NavigationPage(new Views.VerifyPasswordPage());
				DependencyService.Get<IProgressBar>().Hide();
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

		public int GuestChildrenRemainingCount { get; set; }
		public List<int> SelectedDependents { get; set; }
		#endregion
	}
}
