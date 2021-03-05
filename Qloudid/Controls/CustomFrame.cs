using Xamarin.Forms;

namespace Qloudid.Controls
{
	public class CustomFrame : Frame
	{
		public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CustomFrame), typeof(CornerRadius), typeof(CustomDatePicker));
		public CustomFrame()
		{
			base.CornerRadius = 0;
		}
		public new CornerRadius CornerRadius
		{
			get => (CornerRadius)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}
	}
}
