using System;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Qloudid.ViewModels;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentificatorPhotoPage : ContentPage
	{
		IdentificatorPhotoPageViewModel viewModel;
		public IdentificatorPhotoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IdentificatorPhotoPageViewModel(this.Navigation);
		}

		#region Image Data1 Clicked.
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
		#endregion

		#region Image Data2 Clicked.
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
		#endregion

		#region Take Photo.
		private async Task TakePhoto(int index)
		{
			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
				Directory = "Sample",
				Name = "test.jpg"
			});

			if (file == null) return;
			var stream = file.GetStream();
			if (index == 1)
			{

				//Helper.Helper.StreamImageData1 = stream;
				//viewModel.StreamImageData1 = stream;
				//image1.Source = ImageSource.FromStream(() => stream);
				//viewModel.Image1 = image1;
				image1.Source = ImageSource.FromStream(() =>
				{
					return file.GetStream();
				});
				viewModel.Image1 = image1;
			}
			else
			{
				image2.Source = ImageSource.FromStream(() =>
				{
					return file.GetStream();
				});
				viewModel.Image2 = image2;
				//viewModel.StreamImageData2 = stream;
				//image2.Source = ImageSource.FromStream(() => stream);
			}
			//file.Dispose();

			/*var stream1 = file.GetStream();
			var bytes = new byte[stream1.Length];
			await stream1.ReadAsync(bytes, 0, (int)stream1.Length);
			if (index == 1)
				viewModel.ImageData1 = Convert.ToBase64String(bytes);
			else
				viewModel.ImageData2 = Convert.ToBase64String(bytes);*/
		}
		#endregion

		#region Pick Photo.
		private async Task PickPhoto(int index)
		{
			if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
				return;
			}

			//Stream stream = null;
			var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
			{
				PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
			});

			if (file == null) return;
		//	stream = file.GetStream();
			if (index == 1)
			{
				//viewModel.StreamImageData1 = stream;
				//image1.Source = ImageSource.FromStream(() => stream);
				
				image1.Source = ImageSource.FromStream(() =>
				{
					return file.GetStream();
				});
				viewModel.Image1 = image1;
			}
			else
			{
				image2.Source = ImageSource.FromStream(() =>
				{
					return file.GetStream();
				});
				viewModel.Image2 = image2;
				//Helper.Helper.StreamImageData2 = stream;
				//viewModel.StreamImageData2 = stream;
				//image2.Source = ImageSource.FromStream(() => stream);
			}
			//file.Dispose();

			/*var stream1 = file.GetStream();
			var bytes = new byte[stream1.Length];
			await stream1.ReadAsync(bytes, 0, (int)stream1.Length);
			if (index == 1)
				viewModel.ImageData1 = Convert.ToBase64String(bytes);
			else
				viewModel.ImageData2 = Convert.ToBase64String(bytes);*/

		}
		#endregion
	}
}