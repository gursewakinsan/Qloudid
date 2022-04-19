using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreCheckInPage : ContentPage
	{
		PreCheckInPageViewModel viewModel;
		public PreCheckInPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new PreCheckInPageViewModel(this.Navigation);
		}
	}
}