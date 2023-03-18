﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class VerifyDependentPasswordPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VerifyDependentPasswordPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
					int id = 0;
					int verificationInfo = 0;
					IHotelService hotelService = new HotelService();
					switch (VerifyPreCheckInDependentInfo.SelectedVerifyDependentType)
					{
						case Models.VerifyDependentType.ByPhone:
							verificationInfo = 2;
							id = await hotelService.PhoneIinviteAdultForCheckinAsync(new Models.PhoneIinviteAdultForCheckinRequest()
							{
								CheckId = Helper.Helper.HotelCheckedIn,
								UserId = Helper.Helper.UserId,
								PhoneNumber = VerifyPreCheckInDependentInfo.PhoneNumber,
								CountryId = VerifyPreCheckInDependentInfo.CountryId
							});
							if (id == 0)
							{
								await Helper.Alert.DisplayAlert("You can't invite your self.");
								return;
							}
							break;
						case Models.VerifyDependentType.ByEmail:
							verificationInfo = 2;
							id = await hotelService.EmailIinviteAdultForCheckinAsync(new Models.EmailIinviteAdultForCheckinRequest()
							{
								Email = VerifyPreCheckInDependentInfo.EmailAddress,
								CheckId = Helper.Helper.HotelCheckedIn,
								UserId = Helper.Helper.UserId
							});
							if (id == 0)
							{
								await Helper.Alert.DisplayAlert("You can't invite your self.");
								return;
							}
							break;
						case Models.VerifyDependentType.OnlyAdult:
							verificationInfo = 1;
							id = await hotelService.AddDependentChekinAsync(new Models.AddDependentChekinRequest()
							{
								CheckId = Helper.Helper.HotelCheckedIn,
								ChildId = VerifyPreCheckInDependentInfo.AdultId
							});
							break;
					}
					await hotelService.VerifyDependentChekInAsync(new Models.VerifyDependent()
					{
						Id = id,
						CheckId = Helper.Helper.HotelCheckedIn,
						VerificationInfo = verificationInfo
					});

					IPreCheckInService preCheckInService = new PreCheckInService();
					var updatePreCheckinStatusResponse = await preCheckInService.UpdatePreCheckinStatusAsync(new Models.UpdatePreCheckinStatusRequest()
					{
						Id = PreCheckinStatusInfo.Id
					});
					if (updatePreCheckinStatusResponse.TotalLeft == 0)
						Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
					else
						Application.Current.MainPage = new NavigationPage(new Views.PreCheckIn.AdultsAndChildrenInfoPage(updatePreCheckinStatusResponse.GuestChildrenLeft, updatePreCheckinStatusResponse.GuestAdultLeft));
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
						Password6Bg = Color.FromHex("#2F3135");
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
			Password1Bg = Password2Bg = Password3Bg = Color.FromHex("#2F3135");
			Password4Bg = Password5Bg = Password6Bg = Color.FromHex("#2F3135");
			switch (index)
			{
				case 1:
					Password1 = "|";
					Password2 = string.Empty;
					Password1Bg = Color.FromHex("#6263ED");
					break;
				case 2:
					Password2 = "|";
					Password3 = string.Empty;
					Password2Bg = Color.FromHex("#6263ED");
					break;
				case 3:
					Password3 = "|";
					Password4 = string.Empty;
					Password3Bg = Color.FromHex("#6263ED");
					break;
				case 4:
					Password4 = "|";
					Password5 = string.Empty;
					Password4Bg = Color.FromHex("#6263ED");
					break;
				case 5:
					Password5 = "|";
					Password6 = string.Empty;
					Password5Bg = Color.FromHex("#6263ED");
					break;
				case 6:
					Password6 = "|";
					Password6Bg = Color.FromHex("#6263ED");
					break;
			}
		}
		#endregion

		#region Back Button Command.
		private ICommand backButtonCommand;
		public ICommand BackButtonCommand
		{
			get => backButtonCommand ?? (backButtonCommand = new Command(() => ExecuteBackButtonCommand()));
		}
		private void ExecuteBackButtonCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
		}
		#endregion

		#region Properties.
		public string UserEmail => Helper.Helper.UserEmail;
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
		public Models.VerifyPreCheckInDependentRequest VerifyPreCheckInDependentInfo { get; set; }
		public Models.GetPreCheckinStatusResponse PreCheckinStatusInfo => Helper.Helper.PreCheckinStatusInfo;
		#endregion
	}
}