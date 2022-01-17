using Xamarin.Forms;
using Android.Content;
using Qloudid.Controls;
using Qloudid.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomOtpEntry), typeof(CustomOtpEntryRenderer))]
namespace Qloudid.Droid.Renderers
{
	public class CustomOtpEntryRenderer : EditorRenderer
	{
		public CustomOtpEntryRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);
			Control.SetCursorVisible(false);
			Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
		}
	}
}