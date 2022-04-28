using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentProfilePage : ContentPage
	{
		DependentProfilePageViewModel viewModel;
		public DependentProfilePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentProfilePageViewModel(this.Navigation);
		}
	}
}