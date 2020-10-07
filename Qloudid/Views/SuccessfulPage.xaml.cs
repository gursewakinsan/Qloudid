using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuccessfulPage : ContentPage
	{
		public SuccessfulPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}
	}
}