﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class GenerateCertificateViewModel : BaseViewModel
	{
		#region Constructor.
		public GenerateCertificateViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Generate Certificate Command.
		private ICommand generateCertificateCommand;
		public ICommand GenerateCertificateCommand
		{
			get => generateCertificateCommand ?? (generateCertificateCommand = new Command(async () => await ExecuteGenerateCertificateCommand()));
		}
		private async Task ExecuteGenerateCertificateCommand()
		{
			if (!string.IsNullOrWhiteSpace(Password))
			{
				if (Password.Length < 6) return;
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.GenerateCertificateRequest request = new Models.GenerateCertificateRequest()
				{
					UserId = Helper.Helper.UserId,
					password = Password
				};
				Models.GenerateCertificateResponse response = await service.GenerateCertificateAsync(request);
				if (response == null)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response.result == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response.result == 1)
				{
					Models.User user = new Models.User()
					{
						first_name = response.first_name,
						last_name = response.last_name,
						user_id = response.user_id,
						email = response.email,
						certificate_key = response.certificate_key,
						result = response.result,
						CardCount = response.card_count,
						PassportCount = response.passport_count
					};
					Helper.Helper.QrCertificateKey = response.certificate_key;
					Helper.Helper.UserId = user.user_id;
					Helper.Helper.UserEmail = user.email;
					Helper.Helper.UserInfo = user;
					if (Application.Current.Properties.Count > 0)
					{
						//Application.Current.Properties.Clear();
						Application.Current.Properties.Remove("QrCode");
						Application.Current.Properties.Remove("FirstName");
						Application.Current.Properties.Remove("LastName");
						Application.Current.Properties.Remove("UserId");
						Application.Current.Properties.Remove("Email");
					}

					Application.Current.Properties.Add("QrCode", response.certificate_key);
					Application.Current.Properties.Add("FirstName", response.first_name);
					Application.Current.Properties.Add("LastName", response.last_name);
					Application.Current.Properties.Add("UserId", response.user_id);
					Application.Current.Properties.Add("Email", response.email);
					await Application.Current.SavePropertiesAsync();

					Helper.Helper.GenerateCertificateIdentificatorValue = response.identificator;
					if (response.identificator == 3)
						Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());

					else if (!response.passport_count || !response.card_count)
					{
						Helper.Helper.IsFirstTime = false;
						Application.Current.MainPage = new NavigationPage(new Views.CompleteSignUpPage());
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());

					/*else if (response.identificator == 1 || response.identificator == 2)
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompletePayInfoMsgPage());
					else if (response.identificator == 0 || response.identificator == -1)
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompleteCheckInInfoPage());*/
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
		#endregion
	}
}
