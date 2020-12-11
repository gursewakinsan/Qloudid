using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedIdentificatorPage : ContentPage
	{
		SelectedIdentificatorViewModel viewModel;
		public SelectedIdentificatorPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SelectedIdentificatorViewModel(this.Navigation);
		}
	}
}