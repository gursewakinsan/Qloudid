using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Info
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WantToCompletePayInfoMsgPage : ContentPage
	{
		WantToCompletePayInfoMsgPageViewModel viewModel;
		public WantToCompletePayInfoMsgPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WantToCompletePayInfoMsgPageViewModel(this.Navigation);
		}
	}
}