using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InviteAdultsByEmailPage : ContentPage
	{
		InviteAdultsByEmailPageViewModel viewModel;
		public InviteAdultsByEmailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InviteAdultsByEmailPageViewModel(this.Navigation);
		}
	}
}