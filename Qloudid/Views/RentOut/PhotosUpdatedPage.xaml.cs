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
    public partial class PhotosUpdatedPage : ContentPage
    {
        #region Variables.
        PhotosUpdatedPageViewModel viewModel;
        private IMedia _mediaPicker;
        ImageSource _imageSource;
        #endregion

        #region Constructor.
        public PhotosUpdatedPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PhotosUpdatedPageViewModel(this.Navigation);
			viewModel.DisplayPhotosCommand.Execute(null);
		}
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
		#endregion

		#region On User Image Clicked.
		private async void OnUserImageClicked(object sender, EventArgs e)
		{
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
					//imgUser.Source = ImageSource.FromStream(mediaFile.GetStream);
					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					//viewModel.UserImageData = imageAsByte;
					viewModel.UserImageData = imageAsByte;
					viewModel.AddApartmentPhotosCommand.Execute(null);

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
				//imgUser.Source = ImageSource.FromStream(mediaFile.GetStream);
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				viewModel.UserImageData = imageAsByte;
				viewModel.AddApartmentPhotosCommand.Execute(null);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
        #endregion

        private void OnListViewItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {

        }

        private async void OnAddNewImageButtonClicked(object sender, EventArgs e)
        {
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

        #region Delete Photo.
        private void OnImageButtonDeletePhotoClicked(object sender, EventArgs e)
        {
			ImageButton control = sender as ImageButton;
			OnDeletePhotoClicked(control.BindingContext as Models.DisplayPhotosResponse);
		}

        private void OnFrameDeletePhotoClicked(object sender, EventArgs e)
        {
			Frame control = sender as Frame;
			OnDeletePhotoClicked(control.BindingContext as Models.DisplayPhotosResponse);
		}

        private void OnLabelDeletePhotoClicked(object sender, EventArgs e)
        {
			Label control = sender as Label;
			OnDeletePhotoClicked(control.BindingContext as Models.DisplayPhotosResponse);
		}

		void OnDeletePhotoClicked(Models.DisplayPhotosResponse deleteDisplayPhotos)
		{ 
			viewModel.DeleteApartmentPhotoCommand.Execute(deleteDisplayPhotos);
		}
		#endregion
	}
}