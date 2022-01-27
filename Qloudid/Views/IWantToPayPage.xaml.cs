using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IWantToPayPage : ContentPage
	{
		IWantToPayPageViewModel viewModel;
		public IWantToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IWantToPayPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.VerifyUserConsentCommand.Execute(null);
		}
	}
}