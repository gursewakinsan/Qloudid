using Xamarin.Forms;
namespace Qloudid.Controls
{
	public class CustomButton : Button
	{
		public CustomButton()
		{
			FontSize = 17;
			BorderWidth = 1;
			CornerRadius = 25;
			HeightRequest = 50;
			TextColor = Color.White;
			BorderColor = Color.White;
			TextTransform = TextTransform.None;
			BackgroundColor = Color.Transparent;
			Margin = new Thickness(40, 0, 40, 0);
		}
	}
}
