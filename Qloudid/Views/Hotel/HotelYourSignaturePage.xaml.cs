using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelYourSignaturePage : ContentPage
	{
		HotelYourSignaturePageViewModel viewModel;
		public HotelYourSignaturePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelYourSignaturePageViewModel(this.Navigation);
		}
	}
}