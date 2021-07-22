using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadDependentPassportPhotoPage : ContentPage
	{
		UploadDependentPassportPhotoPageViewModel viewModel;
		public UploadDependentPassportPhotoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UploadDependentPassportPhotoPageViewModel(this.Navigation);
		}

		private void ImageData1Clicked(object sender, System.EventArgs e)
		{

		}

		private void ImageData2Clicked(object sender, System.EventArgs e)
		{

		}
	}
}