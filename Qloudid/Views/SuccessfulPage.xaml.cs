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

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Helper.Helper.IsBack = true;
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}