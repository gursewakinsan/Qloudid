using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Qloudid.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			LoadApplication(new App(null));
			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var App = (App)Xamarin.Forms.Application.Current;
			if (!string.IsNullOrWhiteSpace(url.Path))
			{
				Helper.Helper.IpFromURL = url.Host;
				Helper.Helper.VerifyUserConsentClientId = url.PathComponents[1];
				int count = url.PathComponents.Count();
				if (count == 3)
					App.OpenAppFromWeb(url.PathComponents[2]);
				else if (count == 4)
				{
					Helper.Helper.PurchaseIndex = Convert.ToInt32(url.PathComponents[3]);
					App.OpenAppFromWeb(url.PathComponents[2]);
				}
			}
			else
			{
				Helper.Helper.IpFromURL = url.Host;
				App.OpenAppFromWeb(string.Empty);
			}
			return false;
		}
	}
}
