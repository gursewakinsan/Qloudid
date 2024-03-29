﻿using Xamarin.Forms;
using Qloudid.Service;
using Xamarin.Essentials;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class InviteAdultsByEmailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InviteAdultsByEmailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Email Address Command.
		private ICommand submitEmailAddressCommand;
		public ICommand SubmitEmailAddressCommand
		{
			get => submitEmailAddressCommand ?? (submitEmailAddressCommand = new Command(async () => await ExecuteSubmitEmailAddressCommand()));
		}
		private async Task ExecuteSubmitEmailAddressCommand()
		{
			if (string.IsNullOrWhiteSpace(EmailAddress))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(EmailAddress))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				Models.VerifyPreCheckInDependentRequest request = new Models.VerifyPreCheckInDependentRequest()
				{
					SelectedVerifyDependentType = Models.VerifyDependentType.ByEmail,
					EmailAddress = EmailAddress
				};
				await Navigation.PushAsync(new Views.PreCheckIn.VerifyDependentPasswordPage(request));

				/*DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				int id = await service.EmailIinviteAdultForCheckinAsync(new Models.EmailIinviteAdultForCheckinRequest()
				{
					Email = EmailAddress,
					CheckId = Helper.Helper.HotelCheckedIn,
					UserId = Helper.Helper.UserId
				});
				if (id == 0)
					await Helper.Alert.DisplayAlert("You can't invite your self.");
				else
				{
					Models.VerifyDependent verify = new Models.VerifyDependent()
					{
						Id = id,
						VerificationInfo = 2,
						CheckId = Helper.Helper.HotelCheckedIn,
					};
					Helper.Helper.VerifyDependentCheckInRequest = verify;
					await Navigation.PushAsync(new Views.PreCheckIn.VerifyDependentPasswordPage());
				}
				DependencyService.Get<IProgressBar>().Hide();*/
			}
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command(async () => await ExecuteBackButtonControlCommand()));
		}
		private async Task ExecuteBackButtonControlCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		public string EmailAddress { get; set; } //= "deservingchandan@gmail.com";
		#endregion
	}
}
