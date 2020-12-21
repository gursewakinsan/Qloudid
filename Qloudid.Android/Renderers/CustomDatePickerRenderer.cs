using Xamarin.Forms;
using Android.Content;
using Qloudid.Controls;
using Qloudid.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace Qloudid.Droid.Renderers
{
	public class CustomDatePickerRenderer : DatePickerRenderer
	{
		public CustomDatePickerRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			CustomDatePicker picker = Element as CustomDatePicker;
			if (!string.IsNullOrWhiteSpace(picker.Placeholder))
				Control.Text = picker.Placeholder;

			this.Control.TextChanged += (sender, arg) => {
				var selectedDate = arg.Text.ToString();
				if (selectedDate == picker.Placeholder)
					Control.Text = picker.Placeholder;
			};
			this.Control.SetBackgroundResource(0);
		}
	}
}