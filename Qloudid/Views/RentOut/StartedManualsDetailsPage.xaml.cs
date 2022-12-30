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
    public partial class StartedManualsDetailsPage : ContentPage
    {
        #region Variables.
        StartedManualsDetailsPageViewModel viewModel;
        private IMedia _mediaPicker;
        ImageSource _imageSource;
        #endregion

        #region Constructor.
        public StartedManualsDetailsPage(Models.GetSratedDetailResponse selectedStartedManuals)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new StartedManualsDetailsPageViewModel(this.Navigation);
            foreach (var item in selectedStartedManuals.Images) item.IsAddNewPhoto = false;
			if (selectedStartedManuals.Images == null)
				selectedStartedManuals.Images = new System.Collections.ObjectModel.ObservableCollection<Models.StartedImages>();
            selectedStartedManuals.Images.Add(new Models.StartedImages() { IsAddNewPhoto = true });
            if (selectedStartedManuals.Images.Count <= 3)
                viewModel.ListViewHeightRequest = 100;
            else if (selectedStartedManuals.Images.Count <= 6)
                viewModel.ListViewHeightRequest = 220;
            else if (selectedStartedManuals.Images.Count <= 9)
                viewModel.ListViewHeightRequest = 340;
            else if (selectedStartedManuals.Images.Count <= 12)
                viewModel.ListViewHeightRequest = 460;
            else
                viewModel.ListViewHeightRequest = 500;
            viewModel.SelectedStartedManuals = selectedStartedManuals;
			if(selectedStartedManuals.IsAvailable)
				viewModel.YesNoButtonCommand.Execute("Yes");
			else
				viewModel.YesNoButtonCommand.Execute("No");

		}
        #endregion

        #region On Add New Button Clicked.
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
				});
				if (mediaFile != null)
				{
					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					viewModel.UserImageData = imageAsByte;
					viewModel.SelectedStartedManuals.Images.Add(new Models.StartedImages()
					{
						ImagePath = mediaFile.Path,
						IsAddNewPhoto = false
					});
					viewModel.UpdateGetStartedPhotosCommand.Execute(null);
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
				var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
				{
					PhotoSize = PhotoSize.Medium,
					CompressionQuality = 90,
				});
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				viewModel.UserImageData = imageAsByte;
				viewModel.SelectedStartedManuals.Images.Add(new Models.StartedImages()
				{
					ImagePath = mediaFile.Path,
					IsAddNewPhoto = false
				});
				viewModel.UpdateGetStartedPhotosCommand.Execute(null);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion
	}
}