﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class RestoreEmailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RestoreEmailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Restore Email Command.
		private ICommand submitRestoreEmailCommand;
		public ICommand SubmitRestoreEmailCommand
		{
			get => submitRestoreEmailCommand ?? (submitRestoreEmailCommand = new Command(async () => await ExecuteSubmitRestoreEmailCommand()));
		}
		private async Task ExecuteSubmitRestoreEmailCommand()
		{
			if (string.IsNullOrWhiteSpace(Email))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(Email))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IAccountRestoreService service = new AccountRestoreService();
				Models.RestoreAccountRequest request = new Models.RestoreAccountRequest()
				{
					Email = Email
				};
				Models.RestoreAccountResponse response = await service.RestoreAccountAsync(request);
				if (response == null)
					await Helper.Alert.DisplayAlert("Somthing went wrong, Please try after some time.");
				else if (response.result == 0)
					await Helper.Alert.DisplayAlert("This email does not exist.");
				else if (response.result == 1)
				{
					Helper.Helper.UserId = response.user_id;
					await Navigation.PushAsync(new Views.RestoreEmailPasswordPage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string Email { get; set; }
		#endregion
	}
}