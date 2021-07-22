using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewDependentPage : ContentPage
	{
		AddNewDependentPageViewModel viewModel;
		public AddNewDependentPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddNewDependentPageViewModel(this.Navigation);
		}
	}
}