using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		TestPageViewModel viewModel;
		public TestPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new TestPageViewModel(this.Navigation);
		}
	}
}