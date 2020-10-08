using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace Qloudid.Droid
{
    [Activity(Label = "Qloudid", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private bool mayBeExit = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		public override void OnBackPressed()
		{
            if (App.Current.MainPage.Navigation.NavigationStack.Count > 0)
            {
                int index = App.Current.MainPage.Navigation.NavigationStack.Count - 1;
                var currentPage = App.Current.MainPage.Navigation.NavigationStack[index];
                if (currentPage is Views.DashboardPage || currentPage is Views.HomePage || currentPage is Views.TimeOutPage)
                {
                    if (!PressBackTwiceToExit())
                    {
                        Process.KillProcess(Process.MyPid());
                        var activity = (Activity)this;
                        activity.FinishAffinity();
                    }
                }
                else
                    base.OnBackPressed();
            }
            else
                base.OnBackPressed();
		}

        private bool PressBackTwiceToExit()
        {
            if (mayBeExit) return false;
            Toast.MakeText(this.BaseContext, "Press BACK once again to exit Qloudid!", ToastLength.Long).Show();
            mayBeExit = true;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                mayBeExit = false;
                return false;
            });
            return true;
        }
    }
}