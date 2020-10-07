using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvalidCertificatePage : ContentPage
	{
		public InvalidCertificatePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}
	}
}