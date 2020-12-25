﻿using System;
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
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				Helper.Helper.IsFirstTime = true;
				MainPage = new NavigationPage(new Views.DashboardPage());
			}
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
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
				if (string.IsNullOrWhiteSpace(signInText))
					MainPage = new NavigationPage(new Views.SignInFromWebPage());
				else
					MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
			}
			else
				MainPage = new NavigationPage(new Views.RestorePage());
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
			if (uri.Host.EndsWith("qloudid.com", StringComparison.OrdinalIgnoreCase))
			{
				if (uri.Segments != null && uri.Segments.Length == 3)
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
									Application.Current.MainPage = new NavigationPage(new Views.SignInFromWebPage());
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
						var clientId = uri.Segments[3].Replace("/", "");
						string signInText = uri.Segments[4];
						Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
						Helper.Helper.VerifyUserConsentClientId = clientId;
						Application.Current.MainPage = new NavigationPage(new Views.SignInFromOtherCompanyPage(signInText));
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
				}
			}
		}
	}
}
