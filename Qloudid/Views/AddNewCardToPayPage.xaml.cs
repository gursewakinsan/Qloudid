using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewCardToPayPage : ContentPage
	{
		AddNewCardToPayPageViewModel viewModel;
		public AddNewCardToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddNewCardToPayPageViewModel(this.Navigation);
		}
	}
}