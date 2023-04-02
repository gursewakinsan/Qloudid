using System;
using System.IO;
using System.Linq;
using Plugin.Media;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Xamarin.Essentials;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using System.Collections.Generic;

namespace Qloudid.Views.AddressBook
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewContactDetailPage : ContentPage
	{
		#region Variables.
		private IMedia _mediaPicker;
		ImageSource _imageSource;
		AddNewContactDetailPageViewModel viewModel;
		#endregion

		#region Constructor.
		public AddNewContactDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddNewContactDetailPageViewModel(this.Navigation);
			GetCountries();
		}
		#endregion

		#region Image Data1 Clicked.
		private async void ImageData1Clicked(object sender, EventArgs e)
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
					if (btn1.IsVisible) btn1.IsVisible = false;
					if (!image1.IsVisible) image1.IsVisible = true;
					image1.Source = ImageSource.FromStream(mediaFile.GetStream);

					var memoryStream = new MemoryStream();
					await mediaFile.GetStream().CopyToAsync(memoryStream);
					byte[] imageAsByte = memoryStream.ToArray();
					viewModel.CroppedImage1 = imageAsByte;
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
				if (btn1.IsVisible) btn1.IsVisible = false;
				if (!image1.IsVisible) image1.IsVisible = true;
				image1.Source = ImageSource.FromStream(mediaFile.GetStream);
				var memoryStream = new MemoryStream();
				await mediaFile.GetStream().CopyToAsync(memoryStream);
				byte[] imageAsByte = memoryStream.ToArray();
				viewModel.CroppedImage1 = imageAsByte;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region Get Countries.
		public void GetCountries()
		{
			if (Helper.Helper.CountryList == null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(AddNewContactDetailPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}
		#endregion

		#region Remove Button Clicked.
		async void OnEmailRemoveClicked(System.Object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			if (viewModel.ListOfContactEmailAddress.Count > 1)
				viewModel.ListOfContactEmailAddress.Remove(button.BindingContext as Models.ContactEmailDetail);
			else
				await Helper.Alert.DisplayAlert("Email information is required.");

		}

		async void OnPhoneRemoveClicked(System.Object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			if (viewModel.ListOfContactPhoneNumber.Count > 1)
				viewModel.ListOfContactPhoneNumber.Remove(button.BindingContext as Models.ContactPhoneNumberDetail);
			else
				await Helper.Alert.DisplayAlert("Phone information is required.");
		}

		async void OnAddressRemoveClicked(System.Object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			if (viewModel.ListOfContactAddressNumber.Count > 1)
				viewModel.ListOfContactAddressNumber.Remove(button.BindingContext as Models.ContactAddressDetail);
			else
				await Helper.Alert.DisplayAlert("Address information is required.");
		}

		async void OnCardRemoveClicked(System.Object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			if (viewModel.ListOfContactCard.Count > 1)
				viewModel.ListOfContactCard.Remove(button.BindingContext as Models.ContactCardDetail);
			else
				await Helper.Alert.DisplayAlert("Card information is required.");
		}
		#endregion
	}
}
