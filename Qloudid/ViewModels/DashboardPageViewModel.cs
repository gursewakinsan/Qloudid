﻿using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class DashboardPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DashboardPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			UserInfo = Helper.Helper.UserInfo;
			if (UserInfo == null) UserInfo = new Models.User();
			if (UserInfo.UserImage == null)
				UserImage = string.Empty;
			else
				UserImage = UserInfo.UserImage;  //ImageSource.FromUri(new Uri(UserInfo.UserImage));
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
			string[] ip = qrCode.Split('/');
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey, new Models.UpdateLoginIP() { ip = ip[0] });
			if (response == 1)
			{
				if (ip.Length == 1)
					await Navigation.PushAsync(new Views.VerifyPasswordPage());
				else
				{
					Helper.Helper.IpFromURL = ip[0];
					Helper.Helper.VerifyUserConsentClientId = ip[1];
					await Navigation.PushAsync(new Views.SignInFromOtherCompanyPage(ip[2]));
				}
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

		#region Is Already Login Command.
		private ICommand isAlreadyLoginCommand;
		public ICommand IsAlreadyLoginCommand
		{
			get => isAlreadyLoginCommand ?? (isAlreadyLoginCommand = new Command(async () => await ExecuteIsAlreadyLoginCommand()));
		}
		private async Task ExecuteIsAlreadyLoginCommand()
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();

				ILoginService service = new LoginService();
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response?.result > 0)
				{
					Models.User user = new Models.User();
					user.first_name = $"{Application.Current.Properties["FirstName"]}";
					user.last_name = $"{Application.Current.Properties["LastName"]}";
					user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
					user.email = $"{Application.Current.Properties["Email"]}";
					if (string.IsNullOrWhiteSpace(user.first_name) && string.IsNullOrWhiteSpace(user.last_name))
					{
						user.first_name = response.first_name;
						user.last_name = response.last_name;
						user.user_id = response.id;
						user.email = response.email;
						user.UserImage = response.image;
					}
					user.UserImage = response.image;
					Helper.Helper.UserInfo = user;
					Helper.Helper.UserId = user.user_id;
					UserInfo = user;
					DisplayUserName = $"{user.first_name} {user.last_name}";
					UserImage = response.image;
					//Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				}
				else
					await Navigation.PushAsync(new Views.InvalidCertificatePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		//#region Login From Url Ip Command.
		//private ICommand loginFromUrlIpCommand;
		//public ICommand LoginFromUrlIpCommand
		//{
		//	get => loginFromUrlIpCommand ?? (loginFromUrlIpCommand = new Command(async () => await ExecuteLoginFromUrlIpCommand()));
		//}
		//private async Task ExecuteLoginFromUrlIpCommand()
		//{
		//	if (Application.Current.Properties.ContainsKey("QrCode"))
		//	{
		//		DependencyService.Get<IProgressBar>().Show();
		//		Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
		//		ILoginService service = new LoginService();
		//		Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
		//		if (response.result > 0)
		//		{
		//			Models.User user = new Models.User();
		//			user.first_name = Application.Current.Properties["FirstName"].ToString();
		//			user.last_name = Application.Current.Properties["LastName"].ToString();
		//			user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
		//			user.UserImage = response.image;
		//			Helper.Helper.UserInfo = user;
		//			LoginToDesktopCommand.Execute(Helper.Helper.IpFromURL);
		//		}
		//		else
		//			await Navigation.PushAsync(new Views.InvalidCertificatePage());
		//		DependencyService.Get<IProgressBar>().Hide();
		//	}
		//}
		//#endregion

		#region Get User Image Command.
		private ICommand getUserImageCommand;
		public ICommand GetUserImageCommand
		{
			get => getUserImageCommand ?? (getUserImageCommand = new Command(async () => await ExecuteGetUserImageCommand()));
		}
		private async Task ExecuteGetUserImageCommand()
		{
			if (!string.IsNullOrWhiteSpace(Helper.Helper.QrCertificateKey))
			{
				//DependencyService.Get<IProgressBar>().Show();
				ILoginService service = new LoginService();
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response.result > 0)
				{
					if (!UserImage.Equals(response.image))
					{
						UserImage = response.image; //ImageSource.FromUri(new Uri(response.image));
						Helper.Helper.UserInfo.UserImage = response.image;
					}
				}
				//DependencyService.Get<IProgressBar>().Hide();
			}
			//Helper.Helper.GetCountries();
		}
		#endregion

		#region Manage Card Command.
		private ICommand manageCardCommand;
		public ICommand ManageCardCommand
		{
			get => manageCardCommand ?? (manageCardCommand = new Command(async () => await ExecuteManageCardCommand()));
		}
		private async Task ExecuteManageCardCommand()
		{
			await Navigation.PushAsync(new Views.CardListPage());
		}
		#endregion

		#region Settings Command.
		private ICommand settingsCommand;
		public ICommand SettingsCommand
		{
			get => settingsCommand ?? (settingsCommand = new Command(async () => await ExecuteSettingsCommand()));
		}
		private async Task ExecuteSettingsCommand()
		{
			await Navigation.PushAsync(new Views.SettingsPage());
		}
		#endregion

		#region Properties.
		private Models.User userInfo;
		public Models.User UserInfo
		{
			get => userInfo;
			set
			{
				userInfo = value;
				OnPropertyChanged("UserInfo");
			}
		}


		//public string UserImage1 => "https://www.qloudid.com/estorecss/tmp.jpg"; //Helper.Helper.UserInfo.UserImage; //$"https://www.qloudid.com/estorecss/tmp.jpg";

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

		private string displayUserName;
		public string DisplayUserName
		{
			get => displayUserName;
			set
			{
				displayUserName = value;
				OnPropertyChanged("DisplayUserName");
			}
		}

		public string AppVersion => Xamarin.Essentials.VersionTracking.CurrentVersion;

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
		//public bool IsUserImage => string.IsNullOrEmpty(UserImage) ? false : true;
		//public bool IsAppLogo => string.IsNullOrEmpty(UserImage) ? true : false;
		#endregion
	}
}
