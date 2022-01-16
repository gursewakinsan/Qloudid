using Android.Views;
using Xamarin.Forms;
using Android.Content;
using Qloudid.Controls;
using Qloudid.Droid.Renderers;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomOtpEntry), typeof(CustomOtpEntryRenderer))]
namespace Qloudid.Droid.Renderers
{
	public class CustomOtpEntryRenderer : EntryRenderer
	{
		public CustomOtpEntryRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
		}

		public override bool DispatchKeyEvent(KeyEvent e)
		{
			if (e.Action == KeyEventActions.Down)
			{
				if (e.KeyCode == Keycode.Del)
				{
					if (string.IsNullOrWhiteSpace(Control.Text))
					{
						var entry = (CustomOtpEntry)Element;
						entry.OnBackspacePressed();
					}
				}
			}
			return base.DispatchKeyEvent(e);
		}
	}
}