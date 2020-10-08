using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvalidQrCodePage : ContentPage
	{
		public InvalidQrCodePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}
	}
}