using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CertificateDetailPage : ContentPage
	{
		CertificateDetailPageViewModel viewModel;
		public CertificateDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CertificateDetailPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			viewModel.GetCertificateDetailCommand.Execute(null);
			base.OnAppearing();
		}
	}
}