using Xamarin.Forms;
using Qloudid.Effects;
using Qloudid.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

//[assembly: ExportEffect(typeof(NoKeyboardEffect_Droid), nameof(NoKeyboardEffect))]
namespace Qloudid.Droid.Effects
{
	public class NoKeyboardEffect_Droid : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				if (Control is EditText editText)
				{
					if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
						editText.ShowSoftInputOnFocus = false;
					else
						editText.SetTextIsSelectable(true);
				}
			}
			catch (System.Exception)
			{
			}
		}

		protected override void OnDetached()
		{
		}
	}
}