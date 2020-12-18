using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPreviewPage : ContentPage
	{
		public CameraPreviewPage()
		{
			InitializeComponent();
		}

        async void CameraPreview_ClickEvent(System.Object sender, System.EventArgs e)
        {
			cameraPreview.OnDoing?.Invoke(sender, e);
			Helper.Helper.IsCameraPageImageClicked = true;
			await Task.Delay(1000);
			await Navigation.PopAsync();
		}

        async void OnBackButtonClicked(System.Object sender, System.EventArgs e)
        {
			Helper.Helper.IsCameraPageImageClicked = false;
			await Navigation.PopAsync();
		}
    }
}