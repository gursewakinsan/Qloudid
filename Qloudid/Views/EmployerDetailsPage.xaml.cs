using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerDetailsPage : ContentPage
	{
		EmployerDetailsPageViewModel viewModel;
		public EmployerDetailsPage(Models.EmployerResponse employer)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new EmployerDetailsPageViewModel(this.Navigation);
			viewModel.EmployerDetails = employer;
		}
	}
}