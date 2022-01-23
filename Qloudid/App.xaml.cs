﻿using System;
using System.IO;
using Xamarin.Forms;
using Qloudid.Service;
using Newtonsoft.Json;
using System.Reflection;
using Qloudid.Interfaces;
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
			/*if (Application.Current.Properties.ContainsKey("QrCode"))
				MainPage = new NavigationPage(new Views.DashboardPage());
			else
				MainPage = new NavigationPage(new Views.RestorePage());*/

			MainPage = new NavigationPage(new Views.ReadOnlyDeliveryAddressPage());
		}

		public void OpenAppFromWeb(string signInText)
		{
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
						MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
				}
			}
			else
				MainPage = new NavigationPage(new Views.RestorePage());
		}

		public void AppToAppLogin()
		{
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
				}
				else if (uri.Segments != null && uri.Segments.Length == 5)
				{
					string signInText = string.Empty;
					signInText = uri.Segments[2].Replace("/", "");
					if (signInText.Equals("DstrictsApp"))
						DstrictsAppFunctionality(uri);
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
							MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						MainPage = new NavigationPage(new Views.RestorePage());
				}
			}
		}

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

		public void DstrictsAppFunctionality_iOS(Uri uri)
		{
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
			}
		}

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
				}
			}
			else
				MainPage = new NavigationPage(new Views.RestorePage());
		}

		//OnStart.
		protected override void OnStart()
		{
			Microsoft.AppCenter.AppCenter.Start("ios=a1e809c9-9532-492b-afc0-21c5bcf0c42e;" +
				  "android=144b7d0e-5ec0-4f49-b25d-207f58a6cf4b;",
				  typeof(Microsoft.AppCenter.Analytics.Analytics), typeof(Microsoft.AppCenter.Crashes.Crashes));
			Microsoft.AppCenter.Crashes.Crashes.NotifyUserConfirmation(Microsoft.AppCenter.Crashes.UserConfirmation.AlwaysSend);
			base.OnStart();
		}
	}
}