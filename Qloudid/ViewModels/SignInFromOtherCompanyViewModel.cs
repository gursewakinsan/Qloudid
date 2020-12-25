﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class SignInFromOtherCompanyViewModel : BaseViewModel
	{
		#region Constructor.
		public SignInFromOtherCompanyViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
				await Helper.Alert.DisplayAlert("Somthing went wrong, Please try after some time.");
				Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
			}
			else if (VerifyUserConsent.result == 0)
			{
				Helper.Helper.IpFromURL = "..";
				Application.Current.MainPage = new NavigationPage(new Views.InvalidCertificatePage());
			}
			else
			{
				DisplayName = $"{VerifyUserConsent.first_name} {VerifyUserConsent.last_name}";
				DisplayCompanyName = $"I will hereby sign in under {VerifyUserConsent.company_name}";
				DisplayReceiverCompanyName = $"Receiver : {VerifyUserConsent.company_name}";
				if (!string.IsNullOrEmpty(VerifyUserConsent.image))
					UserImageSource = VerifyUserConsent.image;
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
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			var rs = await service.ClearLoginAsync(Helper.Helper.QrCertificateKey);
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
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
			Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
			await Task.CompletedTask;
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
		#endregion
	}
}