using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReadOnlyDeliveryAddressPage : ContentPage
	{
		ReadOnlyDeliveryAddressPageViewModel viewModel;
		public ReadOnlyDeliveryAddressPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ReadOnlyDeliveryAddressPageViewModel(this.Navigation);
		}
	}
}