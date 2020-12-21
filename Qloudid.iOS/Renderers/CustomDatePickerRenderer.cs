using UIKit;
using System;
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
			if (Control != null)
			{
				Control.Layer.BorderWidth = 0;
				Control.BorderStyle = UITextBorderStyle.None;
			}

			CustomDatePicker picker = Element as CustomDatePicker;
			if (!string.IsNullOrWhiteSpace(picker.Placeholder))
				Control.Text = picker.Placeholder;

			Control.ShouldEndEditing += (textField) =>
			{
				var seletedDate = (UITextField)textField;
				var text = seletedDate.Text;
				if (text == picker.Placeholder)
					Control.Text = picker.Placeholder;
				return true;
			};
		}
		private void OnCanceled(object sender, EventArgs e)
		{
			Control.ResignFirstResponder();
		}
		private void OnDone(object sender, EventArgs e)
		{
			Control.ResignFirstResponder();
		}
	}
}