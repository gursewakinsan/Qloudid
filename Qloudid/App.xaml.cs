using System;
using Xamarin.Forms;

namespace Qloudid
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.HomePage());
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
