using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MissingPreCheckInInfoPage : ContentPage
	{
		MissingPreCheckInInfoPageViewModel viewModel;
		public MissingPreCheckInInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new MissingPreCheckInInfoPageViewModel(this.Navigation);
		}
	}
}