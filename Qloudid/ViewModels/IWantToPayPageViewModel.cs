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
		public Models.VerifyUserConsentResponse VerifyUserConsent { get; set; }
		public Models.User UserInfo => Helper.Helper.UserInfo;
		public string DisplayDate => $"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}";
		#endregion
	}
}
