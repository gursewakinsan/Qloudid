﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class PreCheckInPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PreCheckInPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Check In With Qloud Id Command.
		private ICommand checkInWithQloudIdCommand;
		public ICommand CheckInWithQloudIdCommand
		{
			get => checkInWithQloudIdCommand ?? (checkInWithQloudIdCommand = new Command(async () => await ExecuteCheckInWithQloudIdCommand()));
		}
		private async Task ExecuteCheckInWithQloudIdCommand()
		{
			await Navigation.PushAsync(new Views.PreCheckIn.VerifyPreCheckInPasswordPage());
		}
		#endregion

		#region Back Button Command.
		private ICommand backButtonCommand;
		public ICommand BackButtonCommand
		{
			get => backButtonCommand ?? (backButtonCommand = new Command(() => ExecuteBackButtonCommand()));
		}
		private void ExecuteBackButtonCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
		}
		#endregion

		#region Properties.
		public Models.GetPreCheckinStatusResponse PreCheckinStatusInfo => Helper.Helper.PreCheckinStatusInfo;
		#endregion
	}
}
