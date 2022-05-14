using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClickedBackFromCardListPage : ContentPage
	{
		ClickedBackFromCardListPageViewModel viewModel;
		public ClickedBackFromCardListPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ClickedBackFromCardListPageViewModel(this.Navigation);
		}
	}
}