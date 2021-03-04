using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class ConfirmAndSignSignaturePageViewModel : BaseViewModel
	{
		#region Constructor.
		public ConfirmAndSignSignaturePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Verify Password Command.
		private ICommand verifyPasswordCommand;
		public ICommand VerifyPasswordCommand
		{
			get => verifyPasswordCommand ?? (verifyPasswordCommand = new Command(async () => await ExecuteVerifyPasswordCommand()));
		}
		private async Task ExecuteVerifyPasswordCommand()
		{
			if (!string.IsNullOrWhiteSpace(Password))
			{
				if (Password.Length < 6) return;
				Helper.Helper.IsBack = false;
				DependencyService.Get<IProgressBar>().Show();
				IDashboardService service = new DashboardService();
				int response = await service.VerifyPasswordAsync(Helper.Helper.QrCertificateKey, new SetPassword() { password = Password });
				ClearPassword();
				if (response == 3)
				{
					Helper.Helper.CountDownWrongPassword = 0;
					if (Helper.Helper.IsThirdPartyWebLogin)
					{
						ICreateAccountService accountService = new CreateAccountService();
						int responseAccountService = await accountService.ConfirmPurchaseAsync(new Models.ConfirmPurchaseRequest() { Certificatekey = Helper.Helper.QrCertificateKey });

						Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
						if (Helper.Helper.PurchaseIndex == 1)
						{
							string url = $"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchaseVerify?response_type=code&client_id={Helper.Helper.VerifyUserConsentClientId}&state=xyz&purchase=1";
							await Xamarin.Essentials.Launcher.OpenAsync(url);//"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchaseVerify");
						}
						else
						{
							string url = $"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchase/{Helper.Helper.VerifyUserConsentClientId}";
							await Xamarin.Essentials.Launcher.OpenAsync(url);//"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchase");
						}
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.PurchaseSuccessfulPage());
				}
				else if (response == 2)
				{
					Helper.Helper.CountDownWrongPassword = 0;
					Application.Current.MainPage = new NavigationPage(new Views.TimeOutPage());
				}
				else
				{
					Helper.Helper.CountDownWrongPassword = Helper.Helper.CountDownWrongPassword + 1;
					if (Helper.Helper.CountDownWrongPassword == 3)
					{
						Helper.Helper.CountDownWrongPassword = 0;
						await Navigation.PushAsync(new Views.WrongPassword3TimesPage());
					}
					else
						await Navigation.PushAsync(new Views.WrongVerifyPasswordPage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				await Helper.Alert.DisplayAlert("Please enter password.");
		}
		#endregion

		#region Cancel Verify Password Command.
		private ICommand cancelVerifyPasswordCommand;
		public ICommand CancelVerifyPasswordCommand
		{
			get => cancelVerifyPasswordCommand ?? (cancelVerifyPasswordCommand = new Command(async () => await ExecuteCancelVerifyPasswordCommand()));
		}
		private async Task ExecuteCancelVerifyPasswordCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Keyboard Numeric Clicked Command.
		private ICommand keyboardNumericClickedCommand;
		public ICommand KeyboardNumericClickedCommand
		{
			get => keyboardNumericClickedCommand ?? (keyboardNumericClickedCommand = new Command<string>((selectedNumeric) => ExecuteKeyboardNumericClickedCommand(selectedNumeric)));
		}
		private void ExecuteKeyboardNumericClickedCommand(string selectedNumeric)
		{
			if (Password.Length <= 5)
			{
				switch (Password.Length)
				{
					case 0:
						Password1 = selectedNumeric;
						ChangePasswordBg(2);
						break;
					case 1:
						Password2 = selectedNumeric;
						ChangePasswordBg(3);
						break;
					case 2:
						Password3 = selectedNumeric;
						ChangePasswordBg(4);
						break;
					case 3:
						Password4 = selectedNumeric;
						ChangePasswordBg(5);
						break;
					case 4:
						Password5 = selectedNumeric;
						ChangePasswordBg(6);
						break;
					case 5:
						Password6 = selectedNumeric;
						Password6Bg = Color.FromHex("#F8F8FA");
						break;
				}
				Password = Password + selectedNumeric;
			}
		}
		#endregion

		#region Clear Numeric Clicked Command.
		private ICommand clearNumericClickedCommand;
		public ICommand ClearNumericClickedCommand
		{
			get => clearNumericClickedCommand ?? (clearNumericClickedCommand = new Command(() => ExecuteClearNumericClickedCommand()));
		}
		private void ExecuteClearNumericClickedCommand()
		{
			if (Password?.Length > 0)
			{
				switch (Password.Length)
				{
					case 1:
						Password1 = string.Empty;
						ChangePasswordBg(1);
						break;
					case 2:
						Password2 = string.Empty;
						ChangePasswordBg(2);
						break;
					case 3:
						Password3 = string.Empty;
						ChangePasswordBg(3);
						break;
					case 4:
						Password4 = string.Empty;
						ChangePasswordBg(4);
						break;
					case 5:
						Password5 = string.Empty;
						ChangePasswordBg(5);
						break;
					case 6:
						Password6 = string.Empty;
						ChangePasswordBg(6);
						break;
				}
				Password = Password.Remove(Password.Length - 1, 1);
			}
		}
		#endregion

		#region Clear Password.
		void ClearPassword()
		{
			Password = string.Empty;
			Password1 = Password2 = Password3 = string.Empty;
			Password4 = Password5 = Password6 = string.Empty;
			ChangePasswordBg(1);
		}
		#endregion

		#region Change Password Bg.
		void ChangePasswordBg(int index)
		{
			Password1Bg = Password2Bg = Password3Bg = Color.FromHex("#F8F8FA");
			Password4Bg = Password5Bg = Password6Bg = Color.FromHex("#F8F8FA");
			switch (index)
			{
				case 1:
					Password1 = "|";
					Password2 = string.Empty;
					Password1Bg = Color.FromHex("#3623B7");
					break;
				case 2:
					Password2 = "|";
					Password3 = string.Empty;
					Password2Bg = Color.FromHex("#3623B7");
					break;
				case 3:
					Password3 = "|";
					Password4 = string.Empty;
					Password3Bg = Color.FromHex("#3623B7");
					break;
				case 4:
					Password4 = "|";
					Password5 = string.Empty;
					Password4Bg = Color.FromHex("#3623B7");
					break;
				case 5:
					Password5 = "|";
					Password6 = string.Empty;
					Password5Bg = Color.FromHex("#3623B7");
					break;
				case 6:
					Password6 = "|";
					Password6Bg = Color.FromHex("#3623B7");
					break;
			}
		}
		#endregion

		#region Properties.
		public string Password { get; set; } = string.Empty;

		public string password1 = "|";
		public string Password1
		{
			get => password1;
			set
			{
				password1 = value;
				OnPropertyChanged("Password1");
			}
		}

		public string password2;
		public string Password2
		{
			get => password2;
			set
			{
				password2 = value;
				OnPropertyChanged("Password2");
			}
		}

		public string password3;
		public string Password3
		{
			get => password3;
			set
			{
				password3 = value;
				OnPropertyChanged("Password3");
			}
		}

		public string password4;
		public string Password4
		{
			get => password4;
			set
			{
				password4 = value;
				OnPropertyChanged("Password4");
			}
		}

		public string password5;
		public string Password5
		{
			get => password5;
			set
			{
				password5 = value;
				OnPropertyChanged("Password5");
			}
		}
		public string password6;
		public string Password6
		{
			get => password6;
			set
			{
				password6 = value;
				OnPropertyChanged("Password6");
			}
		}

		public Color password1Bg = Color.FromHex("#3623B7");
		public Color Password1Bg
		{
			get => password1Bg;
			set
			{
				password1Bg = value;
				OnPropertyChanged("Password1Bg");
			}
		}

		public Color password2Bg = Color.FromHex("#F8F8FA");
		public Color Password2Bg
		{
			get => password2Bg;
			set
			{
				password2Bg = value;
				OnPropertyChanged("Password2Bg");
			}
		}

		public Color password3Bg = Color.FromHex("#F8F8FA");
		public Color Password3Bg
		{
			get => password3Bg;
			set
			{
				password3Bg = value;
				OnPropertyChanged("Password3Bg");
			}
		}

		public Color password4Bg = Color.FromHex("#F8F8FA");
		public Color Password4Bg
		{
			get => password4Bg;
			set
			{
				password4Bg = value;
				OnPropertyChanged("Password4Bg");
			}
		}

		public Color password5Bg = Color.FromHex("#F8F8FA");
		public Color Password5Bg
		{
			get => password5Bg;
			set
			{
				password5Bg = value;
				OnPropertyChanged("Password5Bg");
			}
		}
		public Color password6Bg = Color.FromHex("#F8F8FA");
		public Color Password6Bg
		{
			get => password6Bg;
			set
			{
				password6Bg = value;
				OnPropertyChanged("Password6Bg");
			}
		}
		#endregion
	}
}
