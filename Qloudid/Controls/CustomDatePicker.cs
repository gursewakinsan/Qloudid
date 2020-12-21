using Xamarin.Forms;

namespace Qloudid.Controls
{
	public class CustomDatePicker : DatePicker
	{
		public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(CustomDatePicker), defaultValue: default(string));
		public string Placeholder { get; set; }
	}
}
