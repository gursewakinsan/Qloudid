using UIKit;
using Xamarin.Forms;
using Qloudid.Controls;
using Qloudid.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace Qloudid.iOS.Renderers
{
	public class CustomDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			Control.Layer.BorderWidth = 0;
			Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}