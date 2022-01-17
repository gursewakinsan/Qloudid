using UIKit;
using Xamarin.Forms;
using Qloudid.Controls;
using Qloudid.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomOtpEntry), typeof(CustomOtpEntryRenderer))]
namespace Qloudid.iOS.Renderers
{
	public class CustomOtpEntryRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);
			Control.TintColor = UIColor.White;
		}
	}
}