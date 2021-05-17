using System;
using System.IO;
using Xamarin.Forms;
using Qloudid.Service;
using System.Threading;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class IdentificatorPhotoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public IdentificatorPhotoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Upload AddIdentificator Images Command.
		private ICommand uploadAddIdentificatorImagesCommand;
		public ICommand UploadAddIdentificatorImagesCommand
		{
			get => uploadAddIdentificatorImagesCommand ?? (uploadAddIdentificatorImagesCommand = new Command(async () => await ExecuteUploadAddIdentificatorImagesCommand()));
		}
		private async Task ExecuteUploadAddIdentificatorImagesCommand()
		{
			if (CroppedImage1 == null || CroppedImage2 == null)
				await Helper.Alert.DisplayAlert("Please select photo's.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();

			/*Stream stream1 = await GetStreamFromImageSourceAsync(Image1.Source);
			var bytes1 = new byte[stream1.Length];
			await stream1.ReadAsync(bytes1, 0, (int)stream1.Length);
			string imageData1 = Convert.ToBase64String(bytes1);*/
			string imageData1 = Convert.ToBase64String(CroppedImage1);

			/*Stream stream2 = await GetStreamFromImageSourceAsync(Image2.Source);
				var bytes2 = new byte[stream2.Length];
				await stream2.ReadAsync(bytes2, 0, (int)stream2.Length);
				string imageData2 = Convert.ToBase64String(bytes2);*/
			string imageData2 = Convert.ToBase64String(CroppedImage2);

				Models.AddIdentificatorImagesRequest request1 = new Models.AddIdentificatorImagesRequest()
				{
					imageId = 1,
					UserId = Helper.Helper.UserId,
					IdentificatorId = Helper.Helper.SelectedIdentificatorId,
					ImageData = imageData1,
				};
				int response1 = await service.UploadAddIdentificatorImagesAsync(request1);
				if (response1 == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				else if (response1 == 1)
				{
					Models.AddIdentificatorImagesRequest request2 = new Models.AddIdentificatorImagesRequest()
					{
						imageId = 2,
						UserId = Helper.Helper.UserId,
						IdentificatorId = Helper.Helper.SelectedIdentificatorId,
						ImageData = imageData2,
					};
					int response2 = await service.UploadAddIdentificatorImagesAsync(request2);
					if (response2 == 0)
						await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
					else if (response2 == 1)
					{
						//Helper.Helper.IsAddMoreCard = false;
						Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
					}
					DependencyService.Get<IProgressBar>().Hide();
				}
			}
		}
		#endregion

		#region Skip Upload AddIdentificator Images Command.
		private ICommand skipUploadAddIdentificatorImagesCommand;
		public ICommand SkipUploadAddIdentificatorImagesCommand
		{
			get => skipUploadAddIdentificatorImagesCommand ?? (skipUploadAddIdentificatorImagesCommand = new Command(async () => await ExecuteSkipUploadAddIdentificatorImagesCommand()));
		}
		private async Task ExecuteSkipUploadAddIdentificatorImagesCommand()
		{
			//Helper.Helper.IsAddMoreCard = false;
			Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
			await Task.CompletedTask;
		}
		#endregion

		#region Get Stream From Image Source.
		private static async Task<Stream> GetStreamFromImageSourceAsync(ImageSource imageSource, CancellationToken cancellationToken = default(CancellationToken))
		{
			StreamImageSource source = (StreamImageSource)imageSource;
			if (source.Stream != null)
			{
				return await source.Stream(cancellationToken);
			}
			return null;
		}
		#endregion

		#region Properties.
		public Image Image1 { get; set; }
		public Image Image2 { get; set; }

		public byte[] CroppedImage1;

		public byte[] CroppedImage2;
		public string SelectedIdentificatorText => Helper.Helper.SelectedIdentificatorText;
		#endregion
	}
}
