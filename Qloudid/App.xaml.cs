using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;

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
					MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
				}
			}
			else
				MainPage = new NavigationPage(new Views.RestorePage());
		}

		public void AppToAppLogin()
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
				Application.Current.MainPage = new NavigationPage(new Views.SignInOtherAppPage());
			else
				Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
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
						Application.Current.MainPage = new NavigationPage(new Views.SignInOtherAppPage());
					else
						Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
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
									Application.Current.MainPage = new NavigationPage(new Views.SignInFromWebPage(false));
								}
								else
								{
									Helper.Helper.IsFirstTime = false;
									Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
								}
								/* Device.BeginInvokeOnMainThread(async () =>
                                 {
                                     await Current.MainPage.DisplayAlert("ip", msg.Replace("&", " "), "ok");
                                 });*/
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
						Application.Current.MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
				}
				else if (uri.Segments != null && uri.Segments.Length == 6)
				{
					if (Application.Current.Properties.ContainsKey("QrCode"))
					{
						Helper.Helper.IsThirdPartyWebLogin = true;
						string signInText = uri.Segments[4].Replace("/", "");
						Helper.Helper.PurchaseIndex = Convert.ToInt32(uri.Segments[5]);
						Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
						Helper.Helper.UserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
						Helper.Helper.IpFromURL = uri.Segments[2].Replace("/", "");
						Helper.Helper.VerifyUserConsentClientId = uri.Segments[3].Replace("/", "");
						Application.Current.MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
				}
			}
		}
	}
}
