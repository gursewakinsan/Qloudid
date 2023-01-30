using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class ChangeProfilePageViewModel : BaseViewModel
    {
		#region Constructor.
		public ChangeProfilePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Current Country Detail Command.
		private ICommand currentCountryDetailCommand;
		public ICommand CurrentCountryDetailCommand
		{
			get => currentCountryDetailCommand ?? (currentCountryDetailCommand = new Command(async () => await ExecuteCurrentCountryDetailCommand()));
		}
		private async Task ExecuteCurrentCountryDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IMyCountriesService service = new MyCountriesService();
			var currentCountryDetailInfo = await service.CurrentCountryDetailAsync(new Models.CurrentCountryDetailRequest()
			{
				UserId = Helper.Helper.UserId
			});
            foreach (var item in currentCountryDetailInfo)
            {
				if (item.CountryName.Equals("Sweden"))
					item.CountryFlag = "iconFlagOfSweden.png";
				if (item.CountryName.Equals("Spain"))
					item.CountryFlag = "flagOfSpain.png";
			}
			CurrentCountryDetailInfo = currentCountryDetailInfo;

			UserCountrySummary = await service.UserCountrySummaryAsync(new Models.UserCountrySummaryRequest()
			{
				UserId = Helper.Helper.UserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To My Countries Command.
		private ICommand goToMyCountriesCommand;
		public ICommand GoToMyCountriesCommand
		{
			get => goToMyCountriesCommand ?? (goToMyCountriesCommand = new Command(async () => await ExecuteGoToMyCountriesCommand()));
		}
		private async Task ExecuteGoToMyCountriesCommand()
		{
			if (UserCountrySummary == 0)
				await Navigation.PushAsync(new Views.MyCountries.MyCountriesPage());
		}
		#endregion

		#region Selected Current Country Detail Command.
		private ICommand selectedCurrentCountryDetailCommand;
		public ICommand SelectedCurrentCountryDetailCommand
		{
			get => selectedCurrentCountryDetailCommand ?? (selectedCurrentCountryDetailCommand = new Command<Models.CurrentCountryDetailResponse>(async (currentCountry) => await ExecuteSelectedCurrentCountryDetailCommand(currentCountry)));
		}
		private async Task ExecuteSelectedCurrentCountryDetailCommand(Models.CurrentCountryDetailResponse currentCountry)
		{
			DependencyService.Get<IProgressBar>().Show();
			IMyCountriesService service = new MyCountriesService();
			await service.UpdateCountryAsync(new Models.UpdateCountryRequest()
			{
				UserId = Helper.Helper.UserId,
				UpdateInfo = currentCountry.Id
			});
			CurrentCountryDetailCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
		}
		#endregion

		#region Selected Tab Command.
		private ICommand selectedTabCommand;
		public ICommand SelectedTabCommand
		{
			get => selectedTabCommand ?? (selectedTabCommand = new Command<string>((selectedTab) => ExecuteSelectedTabCommand(selectedTab)));
		}
		private void ExecuteSelectedTabCommand(string selectedTab)
		{
			switch (selectedTab)
			{
				case "Country":
					IsChildrenTabSelected = false;
					Helper.Helper.CountryOrChildren = "Country";
					CurrentCountryDetailCommand.Execute(null);
					break;
				case "Children":
					IsChildrenTabSelected = true;
					Helper.Helper.CountryOrChildren = "Children";
					GetAllDependentCommand.Execute(null);
					break;
			}
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

		#region Dependent Detail Command.
		private ICommand dependentDetailCommand;
		public ICommand DependentDetailCommand
		{
			get => dependentDetailCommand ?? (dependentDetailCommand = new Command<int>(async (id) => await ExecuteDependentDetailCommand(id)));
		}
		private async Task ExecuteDependentDetailCommand(int id)
		{
			DependencyService.Get<IProgressBar>().Show();
			IDependentService service = new DependentService();
			Helper.Helper.DependentDetail = await service.DependentDetailAsync(new Models.DependentDetailRequest()
			{
				Id = id
			});
			await Navigation.PushAsync(new Views.Dependent.DependentDetailPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add Country Or Children Command.
		private ICommand addCountryOrChildrenCommand;
		public ICommand AddCountryOrChildrenCommand
		{
			get => addCountryOrChildrenCommand ?? (addCountryOrChildrenCommand = new Command(() => ExecuteAddCountryOrChildrenCommand()));
		}
		private void ExecuteAddCountryOrChildrenCommand()
		{
			if (IsChildrenTabSelected)
				AddNewDependentCommand.Execute(null);
			else
				GoToMyCountriesCommand.Execute(null);
		}
		#endregion

		#region Properties.
		public List<Models.CurrentCountryDetailResponse> currentCountryDetailInfo;
		public List<Models.CurrentCountryDetailResponse> CurrentCountryDetailInfo 
		{
			get => currentCountryDetailInfo;
			set
			{
				currentCountryDetailInfo = value;
				OnPropertyChanged("CurrentCountryDetailInfo");
			}
		}

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

		public int userCountrySummary;
		public int UserCountrySummary
		{
			get => userCountrySummary;
			set
			{
				userCountrySummary = value;
				OnPropertyChanged("UserCountrySummary");
			}
		}

		public bool isChildrenTabSelected;
		public bool IsChildrenTabSelected
		{
			get => isChildrenTabSelected;
			set
			{
				isChildrenTabSelected = value;
				if (isChildrenTabSelected)
				{
					YourAccountsSelectedTab = false;
					ChildrenSelectedTab = true;
				}
				else
				{
					YourAccountsSelectedTab = true;
					ChildrenSelectedTab = false;
				}
				OnPropertyChanged("IsChildrenTabSelected");
			}
		}

		public bool yourAccountsSelectedTab;
		public bool YourAccountsSelectedTab
		{
			get => yourAccountsSelectedTab;
			set
			{
				yourAccountsSelectedTab = value;
				OnPropertyChanged("YourAccountsSelectedTab");
			}
		}

		public bool childrenSelectedTab;
		public bool ChildrenSelectedTab
		{
			get => childrenSelectedTab;
			set
			{
				childrenSelectedTab = value;
				OnPropertyChanged("ChildrenSelectedTab");
			}
		}
		#endregion
	}
}
