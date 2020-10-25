using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PurchaseSuccessfulPage : ContentPage
	{
		PurchaseSuccessfulViewModel viewModel;
		public PurchaseSuccessfulPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new PurchaseSuccessfulViewModel(this.Navigation);
		}
	}
}