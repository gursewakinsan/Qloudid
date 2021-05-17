using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Info
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentificatorPageForCheckIn : ContentPage
	{
		IdentificatorPageForCheckInViewModel viewModel;
		public IdentificatorPageForCheckIn()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IdentificatorPageForCheckInViewModel(this.Navigation);
		}
	}
}