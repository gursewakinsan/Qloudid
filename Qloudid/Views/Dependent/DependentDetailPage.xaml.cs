using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentDetailPage : ContentPage
	{
		DependentDetailPageViewModel viewModel;
		public DependentDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentDetailPageViewModel(this.Navigation);
		}
	}
}