using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class VerifyHotelPasswordPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VerifyHotelPasswordPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			if (Helper.Helper.UserInfo != null)
			{
				if (Helper.Helper.UserInfo.UserImage == null)
					UserImage = string.Empty;
				else
					UserImage = Helper.Helper.UserInfo.UserImage;
			}
			else
				IsAppLogo = true;
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
				int response = await service.VerifyPasswordAsync(Helper.Helper.QrCertificateKey, new SetPassword() 
				{ password = Password });
				ClearPassword();
				if (response == 1)
				{
					Helper.Helper.CountDownWrongPassword = 0;
					if (!string.IsNullOrWhiteSpace(Helper.Helper.HotelBookingId))
						Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelInvoiceAddressListPage());
					else
						await Helper.Alert.DisplayAlert("Hotel id is null and response == 1");
				}
				else if (response == 2)
				{
					Helper.Helper.CountDownWrongPassword = 0;
					Application.Current.MainPage = new NavigationPage(new Views.TimeOutPage());
				}
				else if (response == 3)
				{
					Helper.Helper.CountDownWrongPassword = 0;
					if (!string.IsNullOrWhiteSpace(Helper.Helper.HotelBookingId))
						Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelInvoiceAddressListPage());
					else
						await Helper.Alert.DisplayAlert("Hotel id is null and response == 3");
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
				DependencyService.Get<IProgressBar>().Show();
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

		#region Login To Desktop Command.
		private ICommand loginToDesktopCommand;
		public ICommand LoginToDesktopCommand
		{
			get => loginToDesktopCommand ?? (loginToDesktopCommand = new Command<string>(async (qrCode) => await ExecuteLoginToDesktopCommand(qrCode)));
		}
		private async Task ExecuteLoginToDesktopCommand(string qrCode)
		{
			DependencyService.Get<IProgressBar>().Show();
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
						ChangePasswordBg(1);
						break;
					case 1:
						Password2 = selectedNumeric;
						ChangePasswordBg(2);
						break;
					case 2:
						Password3 = selectedNumeric;
						ChangePasswordBg(3);
						break;
					case 3:
						Password4 = selectedNumeric;
						ChangePasswordBg(4);
						break;
					case 4:
						Password5 = selectedNumeric;
						ChangePasswordBg(5);
						break;
					case 5:
						Password6 = selectedNumeric;
						ChangePasswordBg(6);
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
						Password6Bg = Color.FromHex("#281F91");
						break;
				}
				Password = Password.Remove(Password.Length - 1, 1);
			}
			else
				Password1Bg = Color.FromHex("#281F91");
		}
		#endregion

		#region Cancel Command.
		private ICommand cancelCommand;
		public ICommand CancelCommand
		{
			get => cancelCommand ?? (cancelCommand = new Command(async () => await ExecuteCancelCommand()));
		}
		private async Task ExecuteCancelCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			Models.ClearCertificateRequest request = new Models.ClearCertificateRequest()
			{
				certi = Helper.Helper.QrCertificateKey
			};
			await service.ClearCertificateAsync(request);
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
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
			Password1Bg = Password2Bg = Password3Bg = Color.FromHex("#2F3135");
			Password4Bg = Password5Bg = Password6Bg = Color.FromHex("#2F3135");
			switch (index)
			{
				case 1:
					//Password1 = "|";
					Password2 = string.Empty;
					Password1Bg = Color.FromHex("#6263ED");
					break;
				case 2:
					//Password2 = "|";
					Password3 = string.Empty;
					Password2Bg = Color.FromHex("#6263ED");
					break;
				case 3:
					//Password3 = "|";
					Password4 = string.Empty;
					Password3Bg = Color.FromHex("#6263ED");
					break;
				case 4:
					//Password4 = "|";
					Password5 = string.Empty;
					Password4Bg = Color.FromHex("#6263ED");
					break;
				case 5:
					//Password5 = "|";
					Password6 = string.Empty;
					Password5Bg = Color.FromHex("#6263ED");
					break;
				case 6:
					//Password6 = "|";
					Password6Bg = Color.FromHex("#6263ED");
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

		public Color password1Bg = Color.FromHex("#6263ED");
		public Color Password1Bg
		{
			get => password1Bg;
			set
			{
				password1Bg = value;
				OnPropertyChanged("Password1Bg");
			}
		}

		public Color password2Bg = Color.FromHex("#2F3135");
		public Color Password2Bg
		{
			get => password2Bg;
			set
			{
				password2Bg = value;
				OnPropertyChanged("Password2Bg");
			}
		}

		public Color password3Bg = Color.FromHex("#2F3135");
		public Color Password3Bg
		{
			get => password3Bg;
			set
			{
				password3Bg = value;
				OnPropertyChanged("Password3Bg");
			}
		}

		public Color password4Bg = Color.FromHex("#2F3135");
		public Color Password4Bg
		{
			get => password4Bg;
			set
			{
				password4Bg = value;
				OnPropertyChanged("Password4Bg");
			}
		}

		public Color password5Bg = Color.FromHex("#2F3135");
		public Color Password5Bg
		{
			get => password5Bg;
			set
			{
				password5Bg = value;
				OnPropertyChanged("Password5Bg");
			}
		}
		public Color password6Bg = Color.FromHex("#2F3135");
		public Color Password6Bg
		{
			get => password6Bg;
			set
			{
				password6Bg = value;
				OnPropertyChanged("Password6Bg");
			}
		}

		private string userImage;
		public string UserImage
		{
			get => userImage;
			set
			{
				userImage = value;
				OnPropertyChanged("UserImage");
				IsUserImage = string.IsNullOrWhiteSpace(value) ? false : true;
				IsAppLogo = string.IsNullOrWhiteSpace(value) ? true : false;
			}
		}

		private bool isUserImage;
		public bool IsUserImage
		{
			get => isUserImage;
			set
			{
				isUserImage = value;
				OnPropertyChanged("IsUserImage");
			}
		}

		private bool isAppLogo;
		public bool IsAppLogo
		{
			get => isAppLogo;
			set
			{
				isAppLogo = value;
				OnPropertyChanged("IsAppLogo");
			}
		}
		#endregion
	}
}