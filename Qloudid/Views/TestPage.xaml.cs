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
	public partial class TestPage : ContentPage
	{
		TestPageViewModel viewModel;
		ImageSource _imageSource;
		private IMedia _mediaPicker;
		public TestPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new TestPageViewModel(this.Navigation);
		}

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			var action = await DisplayActionSheet(null, "Cancel", null, "Photo Library", "Take Photo");
			if (action == "Photo Library")
				await SelectPicture();
			else if (action == "Take Photo")
				await TakePicture();
			else if (action == "Cancel")
				return;
		}

		private void Refresh()
		{
			try
			{
				if (App.CroppedImage != null)
				{
					Stream stream = new MemoryStream(App.CroppedImage);
					//image.Source = ImageSource.FromStream(() => stream);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		private async void Setup()
		{
			if (_mediaPicker != null)
			{
				return;
			}

			////RM: hack for working on windows phone? 
			await CrossMedia.Current.Initialize();
			_mediaPicker = CrossMedia.Current;
		}

		private async Task SelectPicture()
		{
			Setup();

			_imageSource = null;

			try
			{

				var mediaFile = await this._mediaPicker.PickPhotoAsync();

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

		private async Task TakePicture()
		{
			Setup();

			_imageSource = null;

			try
			{
				var mediaFile = await this._mediaPicker.TakePhotoAsync(new StoreCameraMediaOptions
				{
					DefaultCamera = CameraDevice.Rear
				});

				_imageSource = ImageSource.FromStream(mediaFile.GetStream);

				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();

				await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	}
}