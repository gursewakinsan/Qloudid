using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MobileNumberPage : ContentPage
	{
		MobileNumberPageViewModel viewModel;
		public MobileNumberPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new MobileNumberPageViewModel(this.Navigation);
		}
	}
}