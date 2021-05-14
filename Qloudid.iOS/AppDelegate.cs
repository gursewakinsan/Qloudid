using UIKit;
using System;
using Foundation;
using System.Linq;
using Xamarin.Forms;

namespace Qloudid.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.SetFlags("Brush_Experimental");
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
				else if (count == 4 || count==5)
				{
					Helper.Helper.PurchaseIndex = Convert.ToInt32(url.PathComponents[3]);
					string text = url.PathComponents[2];

					if (count == 5)
						Helper.Helper.ClientIdForHotel = url.PathComponents[4];

					if (text.Equals("hotel"))
						Helper.Helper.HotelBookingId = url.PathComponents[1];
					else if (text.Equals("checkin"))
						Helper.Helper.HotelCheckinId = url.PathComponents[1];
					App.OpenAppFromWeb(url.PathComponents[2]);
				}
			}
			else
			{
				if (url.Host.Equals("NoffaPlusApp"))
				{
					//App to App Login
					App.AppToAppLogin();
				}
				else
				{
					Helper.Helper.IpFromURL = url.Host;
					App.OpenAppFromWeb(string.Empty);
				}
			}
			return false;
		}
	}
}
