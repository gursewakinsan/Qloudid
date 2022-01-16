using Xamarin.Forms;
using Android.Content;
using Qloudid.Controls;
using Qloudid.Droid.Renderers;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFloatingLabelEntry), typeof(CustomFloatingLabelEntryRenderer))]
namespace Qloudid.Droid.Renderers
{
	public class CustomFloatingLabelEntryRenderer : EntryRenderer
	{
		public CustomFloatingLabelEntryRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
		}
	}
}