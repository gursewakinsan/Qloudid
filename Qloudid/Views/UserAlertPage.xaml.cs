using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserAlertPage : ContentPage
	{
		public UserAlertPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}
	}
}