using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class IWantToPayPageViewModel : BaseViewModel
	{
		#region Constructor.
		public IWantToPayPageViewModel(INavigation navigation)
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
				LoginToDesktopCommand.Execute(Helper.Helper.IpFromURL);
			}
			//DependencyService.Get<IProgressBar>().Hide();
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
			await service.ClearLoginAsync(Helper.Helper.QrCertificateKey);
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
			Helper.Helper.FromIWantToPayPage = true;
			await Navigation.PushAsync(new Views.SignInFromOtherCompanyPage(""));
		}
		#endregion

		#region Login To Desktop Command.
		private ICommand loginToDesktopCommand;
		public ICommand LoginToDesktopCommand
		{
			get => loginToDesktopCommand ?? (loginToDesktopCommand = new Command<string>(async (qrCode) => await ExecuteLoginToDesktopCommand(qrCode)));
		}
		private async Task ExecuteLoginToDesktopCommand(string qrCode)
		{
			IDashboardService service = new DashboardService();
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey, new Models.UpdateLoginIP() { ip = qrCode });
			if (response == 1)
			{
				if (Helper.Helper.UserInfo == null)
				{
					Models.User user = new Models.User();
					user.first_name = $"{Application.Current.Properties["FirstName"]}";
					user.last_name = $"{Application.Current.Properties["LastName"]}";
					user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
					user.email = $"{Application.Current.Properties["Email"]}";
					Helper.Helper.UserInfo = user;
				}
				DependencyService.Get<IProgressBar>().Hide();
				return;
			}
			else if (response == 2)
				await Navigation.PushAsync(new Views.InvalidQrCodePage());
			else if (response == 3)
				await Navigation.PushAsync(new Views.UserUnauthorizedPage());
			else
				await Navigation.PushAsync(new Views.UserAlertPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Login From Url Ip Command.
		private ICommand loginFromUrlIpCommand;
		public ICommand LoginFromUrlIpCommand
		{
			get => loginFromUrlIpCommand ?? (loginFromUrlIpCommand = new Command(async () => await ExecuteLoginFromUrlIpCommand()));
		}
		private async Task ExecuteLoginFromUrlIpCommand()
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				//DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
				ILoginService service = new LoginService();
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response.result > 0)
				{
					Models.User user = new Models.User()
					{
						first_name = response.first_name,
						last_name = response.last_name,
						email = response.email,
						user_id = response.id,
						UserImage = response.image,
					};
					Helper.Helper.UserInfo = user;
					LoginToDesktopCommand.Execute(Helper.Helper.IpFromURL);
				}
				else
					await Navigation.PushAsync(new Views.InvalidCertificatePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
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

		private Models.VerifyUserConsentResponse verifyUserConsent;
		public Models.VerifyUserConsentResponse VerifyUserConsent
		{
			get => verifyUserConsent;
			set
			{
				verifyUserConsent = value;
				OnPropertyChanged("VerifyUserConsent");
			}
		}

		public Models.User UserInfo => Helper.Helper.UserInfo;
		public string DisplayDate => $"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}";
		#endregion
	}
}
