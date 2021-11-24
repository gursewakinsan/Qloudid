using Xamarin.Forms;
using Qloudid.Service;
using Xamarin.Essentials;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class VerifyAddPersonToDesiredQueuePasswordViewModel : BaseViewModel
	{
		#region Constructor.
		public VerifyAddPersonToDesiredQueuePasswordViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Check Valid QR Command.
		private ICommand _checkValidQrCommand;
		public ICommand CheckValidQrCommand
		{
			get => _checkValidQrCommand ?? (_checkValidQrCommand = new Command(async () => await ExecuteCheckValidQrCommand()));
		}
		private async Task ExecuteCheckValidQrCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
			ILoginService service = new LoginService();
			Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
			if (response?.result > 0)
			{
				Models.User user = new Models.User()
				{
					first_name = response.first_name,
					last_name = response.last_name,
					user_id = response.id,
					email = response.email,
					UserImage = response.image,
				};
				Helper.Helper.UserInfo = user;
				Helper.Helper.UserId = user.user_id;
			}
			else
				await Navigation.PushAsync(new Views.InvalidCertificatePage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Verify Inter App Password Command.
		private ICommand verifyInterAppPasswordCommand;
		public ICommand VerifyInterAppPasswordCommand
		{
			get => verifyInterAppPasswordCommand ?? (verifyInterAppPasswordCommand = new Command(async () => await ExecuteVerifyInterAppPasswordCommand()));
		}
		private async Task ExecuteVerifyInterAppPasswordCommand()
		{
			if (!string.IsNullOrWhiteSpace(Password))
			{
				if (Password.Length < 6) return;
				DependencyService.Get<IProgressBar>().Show();
				IInterAppService service = new InterAppService();
				Models.InterAppRequest request = new Models.InterAppRequest()
				{
					Password = Password,
					Certificate = Helper.Helper.QrCertificateKey
				};
				Models.InterAppResponse response = await service.VerifyInterAppPasswordAsync(request);
				ClearPassword();
				if (response == null)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response.Result == 0)
				{
					Helper.Helper.CountDownWrongPassword = Helper.Helper.CountDownWrongPassword + 1;
					if (Helper.Helper.CountDownWrongPassword > 2)
					{
						Helper.Helper.CountDownWrongPassword = 0;
						await Navigation.PushAsync(new Views.WrongPassword3TimesPage());
					}
					else
						await Helper.Alert.DisplayAlert("You have enter wrong password, Please try again.");
				}
				else if (response.Result == 1)
				{
					IQueueService queueService = new QueueService();
					int queueServiceResponse = await queueService.AddPersonToDesiredQueueAsync(new Models.AddPersonToDesiredQueueRequest()
					{
						Id = AddPersonToDesiredQueueId,
						UserId = Helper.Helper.UserId
					});

					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
					if (Device.RuntimePlatform == Device.iOS)
					{
						string openAppUrl = string.Empty;
						if (Helper.Helper.AppToAppName.Equals("DstrictsApp"))
							openAppUrl = $"DstrictsAppUrl://session/{response.Session}";
						await Launcher.OpenAsync(openAppUrl);
					}
					else
					{
						var supportsUri = await Launcher.CanOpenAsync($"https://{Helper.Helper.AppToAppName}.com/session/");
						if (supportsUri)
							await Launcher.OpenAsync($"https://{Helper.Helper.AppToAppName}.com/session/" + response.Session);
					}
					Helper.Helper.AppToAppName = string.Empty;
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				await Helper.Alert.DisplayAlert("Please enter password.");
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

		public int AddPersonToDesiredQueueId { get; set; }
		#endregion
	}
}
