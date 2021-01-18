using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewCardPage : ContentPage
	{
		AddNewCardPageViewModel viewModel;
		public AddNewCardPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddNewCardPageViewModel(this.Navigation);
		}
	}
}