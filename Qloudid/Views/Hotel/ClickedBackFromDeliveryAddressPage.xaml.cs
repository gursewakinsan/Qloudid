using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClickedBackFromDeliveryAddressPage : ContentPage
	{
		ClickedBackFromDeliveryAddressPageViewModel viewModel;
		public ClickedBackFromDeliveryAddressPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ClickedBackFromDeliveryAddressPageViewModel(this.Navigation);
		}
	}
}