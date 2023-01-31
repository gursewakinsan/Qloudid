using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompleteSignUpPage : ContentPage
	{
		CompleteSignUpPageViewModel viewModel;
		public CompleteSignUpPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CompleteSignUpPageViewModel(this.Navigation);
		}
	}
}