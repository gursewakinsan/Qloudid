using Xamarin.Forms;
using Qloudid.ViewModels;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.Pickup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectHomeOrPickUpPage : ContentPage
	{
		SelectHomeOrPickUpPageViewModel viewModel;
		public SelectHomeOrPickUpPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SelectHomeOrPickUpPageViewModel(this.Navigation);
		}

		private void OnHomeOrPickUpItemTapped(object sender, ItemTappedEventArgs e)
		{

		}
	}
}