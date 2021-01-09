using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WrongPassword3TimesPage : ContentPage
	{
		WrongPassword3TimesPageViewModel viewModel;
		public WrongPassword3TimesPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WrongPassword3TimesPageViewModel(this.Navigation);
		}
	}
}