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
			/*global::Xamarin.Forms.Forms.SetFlags("CarouselView_Experimental");
			global::Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental");
			Forms.SetFlags("Brush_Experimental");*/
			Xamarin.Forms.Forms.SetFlags(new string[]
			{
				"CarouselView_Experimental",
				"IndicatorView_Experimental",
				"Brush_Experimental"
			});
			global::Xamarin.Forms.Forms.Init();
			ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			Syncfusion.XForms.iOS.TextInputLayout.SfTextInputLayoutRenderer.Init();
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
				if (count == 2)
				{
					if (url.Host.Equals("DstrictsApp"))
						App.DstrictsAppFunctionality_iOS(new Uri(url.AbsoluteString));
				}
				if (count == 3)
				{
					if (url.Host.Equals("DstrictsApp") || url.Host.Equals("dstrictsapp"))
						App.DstrictsAppFunctionality_iOS(new Uri(url.AbsoluteString));
					else if (url.Host.Equals("NoffaPlusApp") || url.Host.Equals("noffaplusapp"))
						App.NoffaPlusAppAppFunctionality_iOS(new Uri(url.AbsoluteString));
					else if (url.PathComponents[1].Equals("precheckin"))
						App.PreCheckInFlow(url.PathComponents[2]);
					else
						App.OpenAppFromWeb(url.PathComponents[2]);
				}
				else if (count == 4 || count == 5)
				{
					Helper.Helper.PurchaseIndex = Convert.ToInt32(url.PathComponents[3]);
					string text = url.PathComponents[2];

					if (count == 5)
						Helper.Helper.ClientIdForHotel = url.PathComponents[4];

					if (text.Equals("hotel"))
						Helper.Helper.HotelBookingId = url.PathComponents[1];
					else if (text.Equals("checkin"))
						Helper.Helper.HotelCheckinId = url.PathComponents[1];
					else if (text.Equals("checkin_dependent"))
						Helper.Helper.ClientIdForHotel = url.PathComponents[4];

					App.OpenAppFromWeb(url.PathComponents[2]);
				}
			}
			else
			{
				if (url.Host.Equals("NoffaPlusApp"))
				{
					//App to App Login
					Helper.Helper.AppToAppName = "NoffaPlusApp";
					App.AppToAppLogin();
				}
				else if(url.Host.Equals("DstrictsApp"))
				{
					//App to App Login
					Helper.Helper.AppToAppName = "DstrictsApp";
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
