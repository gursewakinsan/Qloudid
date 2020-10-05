using UIKit;
using Xamarin.Forms;
using Qloudid.Controls;
using Qloudid.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Qloudid.iOS.Renderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}