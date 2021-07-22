using System;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadDependentPassportPhotoPage : ContentPage
	{
		int index = 0;
		ImageSource _imageSource;
		private IMedia _mediaPicker;
		UploadDependentPassportPhotoPageViewModel viewModel;
		public UploadDependentPassportPhotoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UploadDependentPassportPhotoPageViewModel(this.Navigation);
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
		private async void Refresh()
		{
			try
			{
				if (App.CroppedImage != null)
				{
					Stream stream = new MemoryStream(App.CroppedImage);
					if (index == 1)
					{
						image1.Source = ImageSource.FromStream(() => stream);
						byte[] aa = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(App.CroppedImage, 600, 500);
						viewModel.CroppedImage1 = aa;
						/*if (Device.RuntimePlatform == Device.iOS)
						{
							byte[] aa = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(App.CroppedImage, 600, 500);
							viewModel.CroppedImage1 = aa;
						}
						else
						{
							viewModel.CroppedImage1 = App.CroppedImage;
						}*/
					}
					else
					{
						image2.Source = ImageSource.FromStream(() => stream);
						byte[] bb = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(App.CroppedImage, 600, 500);
						viewModel.CroppedImage2 = bb;
						/*if (Device.RuntimePlatform == Device.iOS)
						{
							byte[] bb = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(App.CroppedImage, 600, 500);
							viewModel.CroppedImage2 = bb;
						}
						else
						{
							viewModel.CroppedImage2 = App.CroppedImage;
						}*/
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
				if (mediaFile != null)
				{
					_imageSource = ImageSource.FromStream(mediaFile.GetStream);
					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));
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
				if (index == 1)
					await Navigation.PushAsync(new CameraPreviewPage("Front"));
				else
					await Navigation.PushAsync(new CameraPreviewPage("Back"));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion
	}
}