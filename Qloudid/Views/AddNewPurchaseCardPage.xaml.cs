using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewPurchaseCardPage : ContentPage
	{
		AddNewPurchaseCardPageViewModel viewModel;
		public AddNewPurchaseCardPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddNewPurchaseCardPageViewModel(this.Navigation);
		}
	}
}