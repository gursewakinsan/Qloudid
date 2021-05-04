using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;
using Qloudid.Interfaces;
using Qloudid.Service;

namespace Qloudid
{
	public partial class App : Application
	{
		public static byte[] CroppedImage;
		public App(string ipFromWeb)
		{
			InitializeComponent();
			Helper.Helper.IsFirstTime = true;
			if (Application.Current.Properties.ContainsKey("QrCode"))
				MainPage = new NavigationPage(new Views.DashboardPage());
			else
				MainPage = new NavigationPage(new Views.RestorePage());
			//GetCountries();
			/*if (string.IsNullOrWhiteSpace(ipFromWeb))
				MainPage = new NavigationPage(new Views.RestorePage());
			else
			{
				if (Application.Current.Properties.ContainsKey("QrCode"))
					MainPage = new NavigationPage(new Views.SignInFromWebPage());
				else
					MainPage = new NavigationPage(new Views.RestorePage());
			}*/
		}

		public void OpenAppFromWeb(string signInText)
		{
			Helper.Helper.IsThirdPartyWebLogin = false;
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				Helper.Helper.QrCertificateKey = $"{Application.Current.Properties["QrCode"]}";
				Helper.Helper.UserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
				if (string.IsNullOrWhiteSpace(signInText))
					MainPage = new NavigationPage(new Views.SignInFromWebPage(false));
				else
				{
					Helper.Helper.IsThirdPartyWebLogin = true;
					if (signInText.Equals("hotel"))
						MainPage = new NavigationPage(new Views.Hotel.HotelBookingDetailPage());
					else if (signInText.Equals("checkin"))
						VerifyCheckinDetail();
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
							break;
						default:
							Device.OpenUri(uri);
							break;
					}
				}
				else if (uri.Segments != null && uri.Segments.Length == 5)
				{
					if (Application.Current.Properties.ContainsKey("QrCode"))
					{
						Helper.Helper.IsThirdPartyWebLogin = true;
						string signInText = uri.Segments[4];
						Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
						Helper.Helper.UserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
						Helper.Helper.IpFromURL = uri.Segments[2].Replace("/", "");
						Helper.Helper.VerifyUserConsentClientId = uri.Segments[3].Replace("/", "");
						MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						MainPage = new NavigationPage(new Views.RestorePage());
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
							MainPage = new NavigationPage(new Views.Hotel.HotelBookingDetailPage());
						}
						else if (signInText.Equals("checkin"))
						{
							Helper.Helper.HotelCheckinId = uri.Segments[3].Replace("/", "");
							VerifyCheckinDetail();
						}
						else
							MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						MainPage = new NavigationPage(new Views.RestorePage());
				}
			}
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
	}
}
