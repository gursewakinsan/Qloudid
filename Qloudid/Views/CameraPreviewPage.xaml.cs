using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPreviewPage : ContentPage
	{
		public CameraPreviewPage(string frontOrBack)
		{
			InitializeComponent();
			BindLabelText(frontOrBack);
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

		void BindLabelText(string frontOrBackPick)
		{
			string text = Helper.Helper.SelectedIdentificatorText;
			if (Helper.Helper.SelectedIdentificatorText == "ID")
				text = "ID Card";
			lblNatigationTitle.Text = text;
			lblHeading.Text = $"{frontOrBackPick} of {text}";
			lblSubHeading.Text = $"Upload the front of your {text}.{Environment.NewLine} Take a clear photo";
		}
	}
}