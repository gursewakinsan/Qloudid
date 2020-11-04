using Xamarin.Forms;
namespace Qloudid.Controls
{
	public class CustomButton : Button
	{
		public CustomButton()
		{
			TextColor = Color.White;
			FontSize = 17;
			CornerRadius = 25;
			HeightRequest = 50;
			BorderColor = Color.White;
			BorderWidth = 1;
			BackgroundColor = Color.Transparent;
			Margin = new Thickness(40, 0, 40, 0);
		}
	}
}
