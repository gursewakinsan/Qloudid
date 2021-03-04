using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class YourSignaturePage : ContentPage
	{
		YourSignaturePageViewModel viewModel;
		public YourSignaturePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new YourSignaturePageViewModel(this.Navigation);
		}
	}
}