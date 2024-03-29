﻿using System;
using System.Timers;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class SignInFromOtherCompanyViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		int count = 0;
		#endregion

		#region Constructor.
		public SignInFromOtherCompanyViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 60000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			DisplayTotalMinutes = $"{count = count + 1} ";
			timer.Start();
		}
		#endregion

		#region Verify User Consent Command.
		private ICommand verifyUserConsentCommand;
		public ICommand VerifyUserConsentCommand
		{
			get => verifyUserConsentCommand ?? (verifyUserConsentCommand = new Command(async () => await ExecuteVerifyUserConsentCommand()));
		}
		private async Task ExecuteVerifyUserConsentCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			Models.VerifyUserConsentRequest request = new Models.VerifyUserConsentRequest()
			{
				certificate = Helper.Helper.QrCertificateKey,
				clientId = Helper.Helper.VerifyUserConsentClientId
			};
			VerifyUserConsent = await service.VerifyUserConsentAsync(request);
			if (VerifyUserConsent == null)
			{
				await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
			}
			else if (VerifyUserConsent.result == 0)
				Application.Current.MainPage = new NavigationPage(new Views.InvalidCertificatePage());
			else
			{
				if (!string.IsNullOrEmpty(Helper.Helper.IpFromURL) && Helper.Helper.PurchaseIndex == 2)
				{
					PurchaseDetail = await service.GetPurchaseDetailAsync(new Models.PurchaseDetailRequest()
					{
						Ip = Helper.Helper.IpFromURL
					});
				}
				else
				{
					PurchaseDetail = new Models.PurchaseDetailResponse()
					{
						CompanyName = "Qloud ID",
						Price = "300"
					};
				}

				Helper.Helper.PurchaseDetail = PurchaseDetail;
				DisplayName = $"{VerifyUserConsent.first_name}";
				/*if (string.IsNullOrEmpty(VerifyUserConsent.company_name))
				{
					DisplayReceiverCompanyName = $"Receiver : Qloud ID";
					DisplayCompanyName = $"I will hereby sign in under Qloud ID.";
				}
				else
				{
					DisplayReceiverCompanyName = $"Receiver : {VerifyUserConsent.company_name}";
					DisplayCompanyName = $"I will hereby sign in under {VerifyUserConsent.company_name}";
				}
				if (!string.IsNullOrEmpty(VerifyUserConsent.image))
					UserImageSource = VerifyUserConsent.image;*/

				/*if (Helper.Helper.UserInfo == null)
					Helper.Helper.UserInfo = new Models.User();
				Helper.Helper.UserInfo.first_name = VerifyUserConsent.first_name;
				Helper.Helper.UserInfo.last_name = VerifyUserConsent.last_name;

				Application.Current.Properties["FirstName"] = VerifyUserConsent.first_name;
				Application.Current.Properties["LastName"] = VerifyUserConsent.last_name;
				await Application.Current.SavePropertiesAsync();*/
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Clear Login Command.
		private ICommand clearLoginCommand;
		public ICommand ClearLoginCommand
		{
			get => clearLoginCommand ?? (clearLoginCommand = new Command(async () => await ExecuteClearLoginCommand()));
		}
		private async Task ExecuteClearLoginCommand()
		{
			if (Helper.Helper.FromIWantToPayPage)
			{
				Helper.Helper.FromIWantToPayPage = false;
				await Navigation.PopAsync();
			}
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ILoginService service = new LoginService();
				await service.ClearLoginAsync(Helper.Helper.QrCertificateKey);
				Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Continue Command.
		private ICommand continueCommand;
		public ICommand ContinueCommand
		{
			get => continueCommand ?? (continueCommand = new Command(async () => await ExecuteContinueCommand()));
		}
		private async Task ExecuteContinueCommand()
		{
			if (Helper.Helper.FromIWantToPayPage)
			{
				DependencyService.Get<IProgressBar>().Show();
				IPickupService pickupService = new PickupService();
				var pickupServiceResponse = await pickupService.PickupAddressDetailAsync(new Models.PickupAddressDetailRequest()
				{
					Certificate = Helper.Helper.QrCertificateKey,
					CompanyId = Helper.Helper.VerifyUserConsentClientId
				});
				if (pickupServiceResponse?.Count > 0)
				{
					Helper.Helper.IsPickupAddressAvailable = true;
					Helper.Helper.IsPickupAddress = true;
					Helper.Helper.PickupAddressList = pickupServiceResponse;
					await Navigation.PushAsync(new Views.Pickup.SelectHomeOrPickUpPage());
				}
				else
				{
					Helper.Helper.IsPickupAddressAvailable = false; ;
					Helper.Helper.IsPickupAddress = false;
					await Navigation.PushAsync(new Views.AddressesListPage());
				}
				Helper.Helper.QloudidPayButtonText = "Qloud ID Pay";
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				Application.Current.MainPage = new NavigationPage(new Views.SignInFromWebPage(true));
		}
		#endregion

		#region Properties.
		public Models.VerifyUserConsentResponse VerifyUserConsent { get; set; }

		public string displayCompanyName;
		public string DisplayCompanyName
		{
			get => displayCompanyName;
			set
			{
				displayCompanyName = value;
				OnPropertyChanged("DisplayCompanyName");
			}
		}

		public string displayName;
		public string DisplayName
		{
			get => displayName;
			set
			{
				displayName = value;
				OnPropertyChanged("DisplayName");
			}
		}

		public Models.PurchaseDetailResponse purchaseDetail;
		public Models.PurchaseDetailResponse PurchaseDetail
		{
			get => purchaseDetail;
			set
			{
				purchaseDetail = value;
				OnPropertyChanged("PurchaseDetail");
			}
		}

		public string userImageSource = "iconUser.png";
		public string UserImageSource
		{
			get => userImageSource;
			set
			{
				userImageSource = value;
				OnPropertyChanged("UserImageSource");
			}
		}

		public string displayReceiverCompanyName;
		public string DisplayReceiverCompanyName
		{
			get => displayReceiverCompanyName;
			set
			{
				displayReceiverCompanyName = value;
				OnPropertyChanged("DisplayReceiverCompanyName");
			}
		}

		private string displayTotalMinutes = "Less then ";
		public string DisplayTotalMinutes
		{
			get => displayTotalMinutes;
			set
			{
				displayTotalMinutes = value;
				OnPropertyChanged("DisplayTotalMinutes");
			}
		}

		public string DisplayDate => $"Date : {DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}";
		#endregion
	}
}
