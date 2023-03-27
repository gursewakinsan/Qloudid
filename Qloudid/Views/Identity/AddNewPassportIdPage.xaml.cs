using System;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace Qloudid.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPassportIdPage : ContentPage
    {
        int index = 0;
        ImageSource _imageSource;
        private IMedia _mediaPicker;
        AddNewPassportIdPageViewModel viewModel;
        public AddNewPassportIdPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewPassportIdPageViewModel(this.Navigation);
        }

		#region Image Data1 Clicked.
		private async void ImageData1Clicked(object sender, EventArgs e)
		{
			index = 1;
			string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
			switch (result)
			{
				case "Take Photo":
					await TakePhoto();
					break;
				case "Pick Photo":
					await PickPhoto();
					break;
			}
		}
		#endregion

		#region Image Data2 Clicked.
		private async void ImageData2Clicked(object sender, EventArgs e)
		{
			index = 2;
			string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
			switch (result)
			{
				case "Take Photo":
					await TakePhoto();
					break;
				case "Pick Photo":
					await PickPhoto();
					break;
			}
		}
		#endregion

		#region Setup.
		private async void Setup()
		{
			if (_mediaPicker != null) return;
			await CrossMedia.Current.Initialize();
			_mediaPicker = CrossMedia.Current;
		}
		#endregion

		#region Pick Photo.
		private async Task PickPhoto()
		{
			Setup();
			_imageSource = null;
			try
			{
				var mediaFile = await this._mediaPicker.PickPhotoAsync(new PickMediaOptions()
				{
					PhotoSize = PhotoSize.Small,
					CompressionQuality = 80
					//CustomPhotoSize = 50
				});
				if (mediaFile != null)
				{
					if (index == 1)
					{
						if (btn1.IsVisible) btn1.IsVisible = false;
						if (!image1.IsVisible) image1.IsVisible = true;
						image1.Source = ImageSource.FromStream(mediaFile.GetStream);
					}
					else
					{
						if (btn2.IsVisible) btn2.IsVisible = false;
						if (!image2.IsVisible) image2.IsVisible = true;
						image2.Source = ImageSource.FromStream(mediaFile.GetStream);
					}
					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					if (index == 1)
						viewModel.CroppedImage1 = imageAsByte;
					else
						viewModel.CroppedImage2 = imageAsByte;


					/*_imageSource = ImageSource.FromStream(mediaFile.GetStream);
					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));*/
				}
			}
			catch (System.Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region Take Photo.
		private async Task TakePhoto()
		{
			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
				return;
			}
			Setup();
			_imageSource = null;
			try
			{
				/*var mediaFile = await this._mediaPicker.TakePhotoAsync(new StoreCameraMediaOptions
				{
					DefaultCamera = CameraDevice.Rear
				});*/

				var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
				{
					PhotoSize = PhotoSize.Medium,
					CompressionQuality = 90,
				});
				if (index == 1)
				{
					if (btn1.IsVisible) btn1.IsVisible = false;
					if (!image1.IsVisible) image1.IsVisible = true;
					image1.Source = ImageSource.FromStream(mediaFile.GetStream);
				}
				else
				{
					if (btn2.IsVisible) btn2.IsVisible = false;
					if (!image2.IsVisible) image2.IsVisible = true;
					image2.Source = ImageSource.FromStream(mediaFile.GetStream);
				}
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				if (index == 1)
					viewModel.CroppedImage1 = imageAsByte;
				else
					viewModel.CroppedImage2 = imageAsByte;

				/*_imageSource = ImageSource.FromStream(mediaFile.GetStream);
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));*/
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion
	}
}
