using System;
using System.IO;
using Xamarin.Forms;
using Qloudid.Service;
using Newtonsoft.Json;
using System.Reflection;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid
{
	public partial class App : Application
	{
		public static byte[] CroppedImage;
		public App(string ipFromWeb)
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIzNzQzQDMxMzkyZTMzMmUzMFBIaTRVTHZ6RSt5ZFl4ZzFkTkhHSWcwTGFnQ0JkUjg4TEJNcnVhSUVZeUE9");
			InitializeComponent();
			Helper.Helper.IsFirstTime = true;
			if (Application.Current.Properties.ContainsKey("QrCode"))
				MainPage = new NavigationPage(new Views.DashboardPage());
			else
				MainPage = new NavigationPage(new Views.RestorePage());

			//MainPage = new NavigationPage(new Views.Dependent.DependentProfilePage());
		}

		public void OpenAppFromWeb(string signInText)
		{
			if (Helper.Helper.UserInfo == null)
				FillUserInfo();
			if (!string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name))
				FillUserInfo();

			Helper.Helper.IsThirdPartyWebLogin = false;
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				Helper.Helper.QrCertificateKey = $"{Application.Current.Properties["QrCode"]}";
				Helper.Helper.UserId = Convert.ToInt32(Application.Current.Properties["UserId"]);

				if (string.IsNullOrWhiteSpace(signInText) || signInText.Equals("login"))
					MainPage = new NavigationPage(new Views.SignInFromWebPage(false));
				else
				{
					Helper.Helper.IsThirdPartyWebLogin = true;
					if (signInText.Equals("hotel"))
						VerifyHotel();
					else if (signInText.Equals("checkin"))
						VerifyCheckinDetail();
					else if (signInText.Equals("checkin_dependent"))
						VerifyUserBookingExists();
					else if (signInText.Equals("payForDishes"))
						VerifyPayForDishes();
					else
						MainPage = new NavigationPage(new Views.IWantToPayPage());
					//MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
				}
			}
			else
				MainPage = new NavigationPage(new Views.RestorePage());
		}

		public void AppToAppLogin()
		{
			if (Helper.Helper.UserInfo == null)
				FillUserInfo();
			if (!string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name))
				FillUserInfo();

			if (Application.Current.Properties.ContainsKey("QrCode"))
				MainPage = new NavigationPage(new Views.SignInOtherAppPage());
			else
				MainPage = new NavigationPage(new Views.RestorePage());
		}

		void GetCountries()
		{
			string jsonFileName = "CountryJson.json";
			var assembly = typeof(MainPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
			using (var reader = new StreamReader(stream))
				Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
		}

		protected override void OnAppLinkRequestReceived(Uri uri)
		{
			if (Helper.Helper.UserInfo == null)
				FillUserInfo();
			if (!string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name))
				FillUserInfo();

			Helper.Helper.IsThirdPartyWebLogin = false;
			if (uri.Host.EndsWith("qloudid.com", StringComparison.OrdinalIgnoreCase))
			{
				if (uri.Segments != null && uri.Segments.Length == 2)
				{
					//App to App Login 
					Helper.Helper.AppToAppName = "NoffaPlusApp";
					if (Application.Current.Properties.ContainsKey("QrCode"))
						MainPage = new NavigationPage(new Views.SignInOtherAppPage());
					else
						MainPage = new NavigationPage(new Views.RestorePage());
				}
				else if (uri.Segments != null && uri.Segments.Length == 3)
				{
					var action = uri.Segments[1].Replace("/", "");
					var msg = uri.Segments[2];
					switch (action)
					{
						case "ip":
							if (!string.IsNullOrEmpty(msg))
							{
								if (msg.Equals("DstrictsApp"))
									DstrictsAppFunctionality(uri);
								else
								{
									if (Application.Current.Properties.ContainsKey("QrCode"))
									{
										Helper.Helper.IpFromURL = msg.Replace("&", " ");
										MainPage = new NavigationPage(new Views.SignInFromWebPage(false));
									}
									else
									{
										Helper.Helper.IsFirstTime = false;
										MainPage = new NavigationPage(new Views.RestorePage());
									}
								}
							}
							break;
						default:
							Device.OpenUri(uri);
							break;
					}
				}
				else if (uri.Segments != null && uri.Segments.Length == 4)
				{
					string signInText = uri.Segments[2].Replace("/", "");
					if (signInText.Equals("DstrictsApp"))
						DstrictsAppFunctionality(uri);
					else if (signInText.Equals("precheckin"))
					{
						PreCheckInFlow(uri.Segments[3]);
					}
				}
				else if (uri.Segments != null && uri.Segments.Length == 5)
				{
					string signInText = string.Empty;
					signInText = uri.Segments[2].Replace("/", "");
					if (signInText.Equals("DstrictsApp"))
						DstrictsAppFunctionality(uri);
					else if(signInText.Equals("NoffaPlusApp"))
						NoffaPlusAppAppFunctionality_Android(uri);
					else
					{
						if (Application.Current.Properties.ContainsKey("QrCode"))
						{
							Helper.Helper.IsThirdPartyWebLogin = true;
							Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
							Helper.Helper.UserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
							Helper.Helper.IpFromURL = uri.Segments[2].Replace("/", "");
							Helper.Helper.VerifyUserConsentClientId = uri.Segments[3].Replace("/", "");
							signInText = uri.Segments[4];
							if (signInText.Equals("login"))
								MainPage = new NavigationPage(new Views.SignInFromWebPage(false));
							else
								MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
						}
						else
							MainPage = new NavigationPage(new Views.RestorePage());
					}
				}
				else if (uri.Segments != null && uri.Segments.Length == 6 || uri.Segments.Length == 7)
				{
					if (Application.Current.Properties.ContainsKey("QrCode"))
					{
						Helper.Helper.IsThirdPartyWebLogin = true;
						string signInText = uri.Segments[4].Replace("/", "");
						Helper.Helper.PurchaseIndex = Convert.ToInt32(uri.Segments[5].Replace("/", ""));
						Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
						Helper.Helper.UserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
						Helper.Helper.IpFromURL = uri.Segments[2].Replace("/", "");
						Helper.Helper.VerifyUserConsentClientId = uri.Segments[3].Replace("/", "");

						if (uri.Segments.Length == 7)
							Helper.Helper.ClientIdForHotel = uri.Segments[6];

						if (signInText.Equals("hotel"))
						{
							Helper.Helper.HotelBookingId = uri.Segments[3].Replace("/", "");
							VerifyHotel();
						}
						else if (signInText.Equals("checkin"))
						{
							Helper.Helper.HotelCheckinId = uri.Segments[3].Replace("/", "");
							VerifyCheckinDetail();
						}
						else if (signInText.Equals("checkin_dependent"))
						{
							VerifyUserBookingExists();
						}
						else if (signInText.Equals("payForDishes"))
						{
							Helper.Helper.PurchaseIndex = Convert.ToInt32(uri.Segments[5].Replace("/", ""));
							VerifyPayForDishes();
						}
						else
							MainPage = new NavigationPage(new Views.IWantToPayPage());
						//MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						MainPage = new NavigationPage(new Views.RestorePage());
				}
			}
		}

		#region Pre Check In Flow
		public async void PreCheckInFlow(string id)
		{
			if (Helper.Helper.UserInfo == null)
				FillUserInfo();
			if (!string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name))
				FillUserInfo();

			IPreCheckInService preCheckInService = new PreCheckInService();
			var responsePreCheckInService = await preCheckInService.GetPreCheckinStatusAsync(new Models.GetPreCheckinStatusRequest()
			{
				Id = id,
				userId = Helper.Helper.UserId
			});
			Helper.Helper.PreCheckinStatusInfo = responsePreCheckInService;

			if (responsePreCheckInService != null)
				Helper.Helper.HotelCheckedIn = responsePreCheckInService.Checkid;

			if (responsePreCheckInService?.Result == 0)
			{
				MainPage = new NavigationPage(new Views.PreCheckIn.UnauthorizedPreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
			else if (responsePreCheckInService?.Result == 1)
			{
				Helper.Helper.IsPreCheckIn = true;
				Helper.Helper.PreCheckinStatus = 1;
				MainPage = new NavigationPage(new Views.PreCheckIn.PreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();

				//MainPage = new NavigationPage(new Views.PreCheckIn.AdultsAndChildrenInfoPage(responsePreCheckInService.GuestChildrenLeft, responsePreCheckInService.GuestAdultLeft));
				//DependencyService.Get<IProgressBar>().Hide();
			}
			else if (responsePreCheckInService?.Result == 2)
			{
				Helper.Helper.IsPreCheckIn = true;
				Helper.Helper.PreCheckinStatus = 2;
				MainPage = new NavigationPage(new Views.PreCheckIn.PreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
			else if (responsePreCheckInService?.Result == 3)
			{
				MainPage = new NavigationPage(new Views.PreCheckIn.AlreadyDonePreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		async void VerifyUserBookingExists()
		{
			Models.CheckInDependentRequest request = new Models.CheckInDependentRequest()
			{
				Ip = Helper.Helper.IpFromURL,
				Id = Helper.Helper.VerifyUserConsentClientId,
				ClientId = Helper.Helper.ClientIdForHotel,
				Certificate = Helper.Helper.QrCertificateKey
			};
			IDependentService dependentService = new DependentService();
			int dependentResponse = await dependentService.VerifyUserBookingExistsAsync(request);
			if (dependentResponse == 0)
				MainPage = new NavigationPage(new Views.Dependent.WrongCheckInDependentPage());
			else if (dependentResponse == 1)
				MainPage = new NavigationPage(new Views.Dependent.EmptyDependentListPage());
			else
			{
				IDashboardService service = new DashboardService();
				int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey,
					new Models.UpdateLoginIP() { ip = Helper.Helper.IpFromURL });

				Helper.Helper.IsFromWebDependent = true;
				MainPage = new NavigationPage(new Views.Dependent.DependentListForCheckInPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}

		async void VerifyCheckinDetail()
		{
			IDashboardService service = new DashboardService();
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey, new Models.UpdateLoginIP() { ip = Helper.Helper.IpFromURL });

			IHotelService hotelService = new HotelService();
			Models.HotelCheckInResponse hotelResponse = await hotelService.VerifyCheckinDetailAsync(new Models.HotelCheckInRequest()
			{
				Id = Helper.Helper.HotelCheckinId,
				Certificate = Helper.Helper.QrCertificateKey
			});
			if (hotelResponse != null)
			{
				if (hotelResponse.UserId.Equals(Helper.Helper.UserId))
				{
					Helper.Helper.IsHotelCheckInFromMobileBrowser = true;
					MainPage = new NavigationPage(new Views.VerifyPasswordPage());
				}
				else
				{
					ILoginService serviceLogin = new LoginService();
					await serviceLogin.ClearLoginAsync(Helper.Helper.QrCertificateKey);
					MainPage = new NavigationPage(new Views.Hotel.HotelCheckInErrorPage());
				}
			}
			else
				MainPage = new NavigationPage(new Views.Hotel.HotelCheckInErrorPage());
		}

		async void VerifyPayForDishes()
		{
			IDashboardService service = new DashboardService();
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey,
				new Models.UpdateLoginIP() { ip = Helper.Helper.IpFromURL });

			Helper.Helper.IsScanQrPayForDishe = false;
			int payForDishesCount = Helper.Helper.PurchaseIndex;
			if (payForDishesCount == 0)
			{
				//Means cash payment for Dishes.
				Helper.Helper.IsCashPayForDishe = true;
				MainPage = new NavigationPage(new Views.PayForDishes.VerifyPayForDishesPasswordPage());
			}
			else if (payForDishesCount == 1)
			{
				//Means payment from card for Dishes.
				Helper.Helper.IsCashPayForDishe = false;
				MainPage = new NavigationPage(new Views.PayForDishes.SelectUserProfileForPayForDishePage());
			}
		}

		async void VerifyHotel()
		{
			IDashboardService service = new DashboardService();
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey,
				new Models.UpdateLoginIP() { ip = Helper.Helper.IpFromURL });

			MainPage = new NavigationPage(new Views.Hotel.HotelBookingDetailPage());
		}

		#region Dstricts App Functionality iOS.
		public void DstrictsAppFunctionality_iOS(Uri uri)
		{
			if (Helper.Helper.UserInfo == null)
				FillUserInfo();
			if (!string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name))
				FillUserInfo();

			Helper.Helper.AppToAppName = "DstrictsApp";
			var action = uri.Segments[1].Replace("/", "");
			switch (action)
			{
				case "LoginDstrictsApp":
					MainPage = new NavigationPage(new Views.SignInOtherAppPage());
					break;
				case "CheckedInHotelId":
					string checkedInHotelId = uri.Segments[2].Replace("/", "");
					MainPage = new NavigationPage(new Views.Hotel.VerifyCheckedInHotelPasswordPage(Convert.ToInt32(checkedInHotelId)));
					break;
				case "DstrictsAppPayOn":
					string[] subs = uri.LocalPath.Split('/');
					Helper.Helper.PayOnRequest = JsonConvert.DeserializeObject<Models.PayOnRequest>(subs[2]);
					if (Helper.Helper.PayOnRequest.QloudIdPay == 1)
						MainPage = new NavigationPage(new Views.DstrictsAppPayOn.SelectUserProfilePageForPayOn());
					else
						MainPage = new NavigationPage(new Views.DstrictsAppPayOn.VerifyPayForPayOnPasswordPage());
					break;
				case "AddPersonToDesiredQueue":
					MainPage = new NavigationPage(new Views.VerifyPassword.VerifyAddPersonToDesiredQueuePasswordPage(uri.Segments[2]));
					break;
				case "DstrictsWaitListResturant":
					string[] waitList = uri.LocalPath.Split('/');
					Models.SubmitWaitListResturantDetail  submitWaitList = JsonConvert.DeserializeObject<Models.SubmitWaitListResturantDetail>(waitList[2]);
					MainPage = new NavigationPage(new Views.WaitList.VerifyWaitResturantPasswordPage(submitWaitList));
					break;
				case "VerifyDependentChekIn":
					string[] verifyDependentCheckIn = uri.LocalPath.Split('/');
					Helper.Helper.VerifyDependentCheckInRequest = JsonConvert.DeserializeObject<Models.VerifyDependent>(verifyDependentCheckIn[2]);
					MainPage = new NavigationPage(new Views.VerifyPassword.VerifyDependentCheckInPasswordPage());
					break;
				case "ConfirmUserInvitationInfo":
					string confirmUserInvitationInfoId = uri.Segments[2].Replace("/", "");
					MainPage = new NavigationPage(new Views.VerifyPassword.ConfirmUserInvitationInfoPasswordPage(confirmUserInvitationInfoId));
					break;
				case "HotelCheckOut":
					int hotelCheckOutId = Convert.ToInt32(uri.Segments[2].Replace("/", ""));
					MainPage = new NavigationPage(new Views.VerifyPassword.VerifyHotelCheckOutPasswordPage(hotelCheckOutId));
					break;
				case "InvitedVisitorsMeetingId":
					Helper.Helper.InvitedVisitorsMeetingId = Convert.ToInt32(uri.Segments[2].Replace("/", ""));
					GetCompanyCommand.Execute(null);
					break;
				case "ShowMissingPreCheckInInfoPage":
					ShowMissingPreCheckInInfoPage(uri.Segments[2].Replace("/", ""));
					break;
			}
		}
		#endregion

		#region Dstricts App Functionality Android.
		public void DstrictsAppFunctionality(Uri uri)
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				Helper.Helper.AppToAppName = "DstrictsApp";
				var action = uri.Segments[3].Replace("/", "");
				switch (action)
				{
					case "LoginDstrictsApp":
						MainPage = new NavigationPage(new Views.SignInOtherAppPage());
						break;
					case "CheckedInHotelId":
						string checkedInHotelId = uri.Segments[4].Replace("/", "");
						MainPage = new NavigationPage(new Views.Hotel.VerifyCheckedInHotelPasswordPage(Convert.ToInt32(checkedInHotelId)));
						break;
					case "DstrictsAppPayOn":
						string[] subs = uri.LocalPath.Split('/');
						Helper.Helper.PayOnRequest = JsonConvert.DeserializeObject<Models.PayOnRequest>(subs[4]);
						if (Helper.Helper.PayOnRequest.QloudIdPay == 1)
							MainPage = new NavigationPage(new Views.DstrictsAppPayOn.SelectUserProfilePageForPayOn());
						else
							MainPage = new NavigationPage(new Views.DstrictsAppPayOn.VerifyPayForPayOnPasswordPage());
						break;
					case "AddPersonToDesiredQueue":
						MainPage = new NavigationPage(new Views.VerifyPassword.VerifyAddPersonToDesiredQueuePasswordPage(uri.Segments[4]));
						break;
					case "DstrictsWaitListResturant":
						string[] waitList = uri.LocalPath.Split('/');
						Models.SubmitWaitListResturantDetail submitWaitList = JsonConvert.DeserializeObject<Models.SubmitWaitListResturantDetail>(waitList[4]);
						MainPage = new NavigationPage(new Views.WaitList.VerifyWaitResturantPasswordPage(submitWaitList));
						break;
					case "VerifyDependentChekIn":
						string[] verifyDependentCheckIn = uri.LocalPath.Split('/');
						Helper.Helper.VerifyDependentCheckInRequest = JsonConvert.DeserializeObject<Models.VerifyDependent>(verifyDependentCheckIn[4]);
						MainPage = new NavigationPage(new Views.VerifyPassword.VerifyDependentCheckInPasswordPage());
						break;
					case "ConfirmUserInvitationInfo":
						string confirmUserInvitationInfoId = uri.Segments[4].Replace("/", "");
						MainPage = new NavigationPage(new Views.VerifyPassword.ConfirmUserInvitationInfoPasswordPage(confirmUserInvitationInfoId));
						break;
					case "HotelCheckOut":
						int hotelCheckOutId = Convert.ToInt32(uri.Segments[4].Replace("/", ""));
						MainPage = new NavigationPage(new Views.VerifyPassword.VerifyHotelCheckOutPasswordPage(hotelCheckOutId));
						break;
					case "InvitedVisitorsMeetingId":
						Helper.Helper.InvitedVisitorsMeetingId = Convert.ToInt32(uri.Segments[4].Replace("/", ""));
						GetCompanyCommand.Execute(null);
						break;
					case "ShowMissingPreCheckInInfoPage":
						ShowMissingPreCheckInInfoPage(uri.Segments[4].Replace("/", ""));
						break;
				}
			}
			else
				MainPage = new NavigationPage(new Views.RestorePage());
		}
		#endregion

		#region Noffa Plus App Functionality Android.
		public void NoffaPlusAppAppFunctionality_Android(Uri uri)
		{
			Helper.Helper.AppToAppName = "NoffaPlusApp";
			var action = uri.Segments[3].Replace("/", "");
			switch (action)
			{
				case "FrontDeskCheckedInHotelRequest":
					string[] subs = uri.LocalPath.Split('/');
					Models.FrontDeskCheckedInHotelRequest request = JsonConvert.DeserializeObject<Models.FrontDeskCheckedInHotelRequest>(subs[4]);
					MainPage = new NavigationPage(new Views.Noffa.VerifyFrontDeskCheckedInHotelRequestPasswordPage(request));
					break;
			}
		}
		#endregion

		#region Noffa Plus App Functionality iOS.
		public void NoffaPlusAppAppFunctionality_iOS(Uri uri)
		{
			Helper.Helper.AppToAppName = "NoffaPlusApp";
			var action = uri.Segments[1].Replace("/", "");
			switch (action)
			{
				case "FrontDeskCheckedInHotelRequest":
					string[] subs = uri.LocalPath.Split('/');
					Models.FrontDeskCheckedInHotelRequest request = JsonConvert.DeserializeObject<Models.FrontDeskCheckedInHotelRequest>(subs[2]);
					MainPage = new NavigationPage(new Views.Noffa.VerifyFrontDeskCheckedInHotelRequestPasswordPage(request));
					break;
			}
		}
		#endregion

		#region On Start.
		protected override void OnStart()
		{
			Microsoft.AppCenter.AppCenter.Start("ios=a1e809c9-9532-492b-afc0-21c5bcf0c42e;" +
				  "android=144b7d0e-5ec0-4f49-b25d-207f58a6cf4b;",
				  typeof(Microsoft.AppCenter.Analytics.Analytics), typeof(Microsoft.AppCenter.Crashes.Crashes));
			Microsoft.AppCenter.Crashes.Crashes.NotifyUserConfirmation(Microsoft.AppCenter.Crashes.UserConfirmation.AlwaysSend);
			base.OnStart();
		}
		#endregion

		#region Fill User Info.
		private static void FillUserInfo()
		{
			Models.User user = new Models.User();
			if (Application.Current.Properties.ContainsKey("FirstName"))
				user.first_name = $"{Application.Current.Properties["FirstName"]}";

			if (Application.Current.Properties.ContainsKey("LastName"))
				user.last_name = $"{Application.Current.Properties["LastName"]}";

			if (Application.Current.Properties.ContainsKey("UserId"))
				user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);

			if (Application.Current.Properties.ContainsKey("Email"))
				user.email = $"{Application.Current.Properties["Email"]}";

			if (Application.Current.Properties.ContainsKey("QrCode"))
				Helper.Helper.QrCertificateKey = $"{Application.Current.Properties["QrCode"]}";

			Helper.Helper.UserInfo = user;

			Helper.Helper.UserId = user.user_id;
			Helper.Helper.UserEmail = user.email;
		}
		#endregion

		#region Get Company List Command.
		private ICommand getCompanyCommand;
		public ICommand GetCompanyCommand
		{
			get => getCompanyCommand ?? (getCompanyCommand = new Command(async () => await ExecuteGetCompanyCommand()));
		}
		private async Task ExecuteGetCompanyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			FillUserInfo();
			IPurchaseService service = new PurchaseService();
			List<Models.Company> response = await service.GetCompanyAsync(new Models.Profile() 
			{ 
				user_id = Helper.Helper.UserId 
			});
			if (response.Count > 0)
				MainPage = new NavigationPage(new Views.Visitors.InvitedVisitorsMeetingUserPage(response));
			else
				MainPage = new NavigationPage(new Views.Visitors.VerifyInvitedVisitorsMeetingPasswordPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Show Missing Pre Check In Info Page.
		async void ShowMissingPreCheckInInfoPage(string id)
		{
			DependencyService.Get<IProgressBar>().Show();
			if (Helper.Helper.UserInfo == null)
				FillUserInfo();
			if (!string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name))
				FillUserInfo();

			IPreCheckInService preCheckInService = new PreCheckInService();
			var responsePreCheckinStatus = await preCheckInService.GetPreCheckinStatusAsync(new Models.GetPreCheckinStatusRequest()
			{
				Id = id,
				userId = Helper.Helper.UserId
			});
			Helper.Helper.PreCheckinStatusInfo = responsePreCheckinStatus;

			var responseUserActiveStatus = await preCheckInService.GetUserActiveStatusAsync(new Models.GetUserActiveStatusRequest()
			{
				UserId = Helper.Helper.UserId
			});
			Helper.Helper.PreCheckInUserActiveStatusInfo = responseUserActiveStatus;
			DependencyService.Get<IProgressBar>().Hide();
			MainPage = new NavigationPage(new Views.PreCheckIn.MissingPreCheckInInfoPage());
		}
		#endregion
	}
}