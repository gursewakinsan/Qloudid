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
		public App(string ipFromWeb)
		{
			InitializeComponent();
			GetCountries();
			if (string.IsNullOrWhiteSpace(ipFromWeb))
				MainPage = new NavigationPage(new Views.RestorePage());
			else
				MainPage = new NavigationPage(new Views.DashboardPage());
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
									Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
								}
								else
									Helper.Helper.IsFirstTime = false;
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
			}
		}
	}
}
