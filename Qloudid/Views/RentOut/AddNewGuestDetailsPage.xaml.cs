using System;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewGuestDetailsPage : ContentPage
    {
        #region Variables.
        private IMedia _mediaPicker;
        ImageSource _imageSource;
        AddNewGuestDetailsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public AddNewGuestDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewGuestDetailsPageViewModel(this.Navigation);
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
		private async Task PickPhoto(int index)
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
					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					if (index == 1)
					{
						imgBtnIdPhotoFront.Source = ImageSource.FromStream(mediaFile.GetStream);
						imgBtnIdPhotoFront.IsVisible = true;
						btnIdPhotoFront.IsVisible = false;
						viewModel.UserImageDataFront = imageAsByte;
					}
					else
					{
						imgBtnIdPhotoBack.Source = ImageSource.FromStream(mediaFile.GetStream);
						imgBtnIdPhotoBack.IsVisible = true;
						btnIdPhotoBack.IsVisible = false;
						viewModel.UserImageDataBack = imageAsByte;
					}
				}
			}
			catch (System.Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region Take Photo.
		private async Task TakePhoto(int index)
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

				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();

				if (index == 1)
				{
					imgBtnIdPhotoFront.Source = ImageSource.FromStream(mediaFile.GetStream);
					imgBtnIdPhotoFront.IsVisible = true;
					btnIdPhotoFront.IsVisible = false;
					viewModel.UserImageDataFront = imageAsByte;
				}
				else
				{
					imgBtnIdPhotoBack.Source = ImageSource.FromStream(mediaFile.GetStream);
					imgBtnIdPhotoBack.IsVisible = true;
					btnIdPhotoBack.IsVisible = false;
					viewModel.UserImageDataBack = imageAsByte;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region On Id Photo Front Clicked.
		private async void OnIdPhotoFrontClicked(object sender, EventArgs e)
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
		#endregion

		#region On Id Photo Back Clicked.
		private async void OnIdPhotoBackClicked(object sender, EventArgs e)
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
		#endregion
	}
}