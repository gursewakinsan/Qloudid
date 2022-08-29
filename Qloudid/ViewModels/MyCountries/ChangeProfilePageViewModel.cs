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
			CurrentCountryDetailInfo = await service.CurrentCountryDetailAsync(new Models.CurrentCountryDetailRequest()
			{
				UserId = Helper.Helper.UserId
			});

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
		#endregion
	}
}
