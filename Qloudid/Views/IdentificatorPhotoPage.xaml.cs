using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System;
using System.Diagnostics;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentificatorPhotoPage : ContentPage
	{
		ImageSource _imageSource;
		private IMedia _mediaPicker;
		IdentificatorPhotoPageViewModel viewModel;
		int index = 0;
		public IdentificatorPhotoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IdentificatorPhotoPageViewModel(this.Navigation);
		}

        protected async override void OnAppearing()
        {
			if (Helper.Helper.IsCameraPageImageClicked)
			{
				Helper.Helper.IsCameraPageImageClicked = false;
				await Navigation.PushModalAsync(new CropView(App.CroppedImage, Refresh));
			}
            base.OnAppearing();
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

		#region Refresh.
		private void Refresh()
		{
			try
			{
				if (App.CroppedImage != null)
				{
					Stream stream = new MemoryStream(App.CroppedImage);
					if (index == 1)
					{
						image1.Source = ImageSource.FromStream(() => stream);
						//viewModel.Image1 = image1;
						viewModel.CroppedImage1 = App.CroppedImage;
					}
					else
					{
						image2.Source = ImageSource.FromStream(() => stream);
						viewModel.CroppedImage2 = App.CroppedImage;
						//viewModel.Image2 = image2;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region Setup.
		private async void Setup()
		{
			if (_mediaPicker != null) return;
			////RM: hack for working on windows phone? 
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
				_imageSource = ImageSource.FromStream(mediaFile.GetStream);
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));
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
				/*var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
				{
					PhotoSize = PhotoSize.Medium,
					CompressionQuality = 90,
				});
				_imageSource = ImageSource.FromStream(mediaFile.GetStream);
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));*/
				await Navigation.PushAsync(new CameraPreviewPage());
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion
	}
}