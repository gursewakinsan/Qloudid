using System;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace Qloudid.Views.MyCountries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVisitingCountryPage : ContentPage
    {
        int index = 0;
		ImageSource _imageSource;
		private IMedia _mediaPicker;
        AddVisitingCountryPageViewModel viewModel;
        public AddVisitingCountryPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddVisitingCountryPageViewModel(this.Navigation);
        }
		

		#region Setup.
		private async void Setup()
		{
			if (_mediaPicker != null) return;
			await CrossMedia.Current.Initialize();
			_mediaPicker = CrossMedia.Current;
		}
		#endregion

		#region Pick Photo.
		private async Task PickPhoto(int imageIndex)
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
					if (imageIndex == 1)
						image1.Source = ImageSource.FromStream(mediaFile.GetStream);
					else
						image2.Source = ImageSource.FromStream(mediaFile.GetStream);

					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();

					if (imageIndex == 1)
						viewModel.UserImageData1 = imageAsByte;
					else
						viewModel.UserImageData2 = imageAsByte;

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
		private async Task TakePhoto(int imageIndex)
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

				if (imageIndex == 1)
					image1.Source = ImageSource.FromStream(mediaFile.GetStream);
				else
					image2.Source = ImageSource.FromStream(mediaFile.GetStream);

				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();

				if (imageIndex == 1)
					viewModel.UserImageData1 = imageAsByte;
				else
					viewModel.UserImageData2 = imageAsByte;

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

        private async void ImageData1Clicked(object sender, EventArgs e)
        {
			string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
			switch (result)
			{
				case "Take Photo":
					await TakePhoto(1);
					break;
				case "Pick Photo":
					await PickPhoto(1);
					break;
			}
		}

        private async void ImageData2Clicked(object sender, EventArgs e)
        {
			string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
			switch (result)
			{
				case "Take Photo":
					await TakePhoto(2);
					break;
				case "Pick Photo":
					await PickPhoto(2);
					break;
			}
		}
    }
}