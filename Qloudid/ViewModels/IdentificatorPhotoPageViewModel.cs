﻿using System;
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
			if (Image1 == null || Image2 == null)
				await Helper.Alert.DisplayAlert("Please select photo's.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				//	var bytes1 = new byte[Helper.Helper.StreamImageData1.Length];
				//await Helper.Helper.StreamImageData1.ReadAsync(bytes1, 0, (int)Helper.Helper.StreamImageData1.Length);
				//ImageData1 = Convert.ToBase64String(bytes1);

				//var bytes2 = new byte[StreamImageData2.Length];
				//await StreamImageData2.ReadAsync(bytes2, 0, (int)StreamImageData2.Length);
				//ImageData2 = Convert.ToBase64String(bytes2);

				Stream stream1 = await GetStreamFromImageSourceAsync(Image1.Source);
				var bytes1 = new byte[stream1.Length];
				await stream1.ReadAsync(bytes1, 0, (int)stream1.Length);
				string imageData1 = Convert.ToBase64String(bytes1);

				Stream stream2 = await GetStreamFromImageSourceAsync(Image2.Source);
				var bytes2 = new byte[stream2.Length];
				await stream2.ReadAsync(bytes2, 0, (int)stream2.Length);
				string imageData2 = Convert.ToBase64String(bytes2);

				Models.AddIdentificatorImagesRequest request1 = new Models.AddIdentificatorImagesRequest()
				{
					ImageData = imageData1,
					imageId = 1,
					UserId = Helper.Helper.UserId
				};
				int response1 = await service.UploadAddIdentificatorImagesAsync(request1);
				if (response1 == 0)
					await Helper.Alert.DisplayAlert("Somthing went wrong, Please try after some time.");
				else if (response1 == 1)
				{
					Models.AddIdentificatorImagesRequest request2 = new Models.AddIdentificatorImagesRequest()
					{
						ImageData = imageData2,
						imageId = 2,
						UserId = Helper.Helper.UserId
					};
					int response2 = await service.UploadAddIdentificatorImagesAsync(request2);
					if (response2 == 0)
						await Helper.Alert.DisplayAlert("Somthing went wrong, Please try after some time.");
					else if (response2 == 1)
						Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
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
		public string SelectedIdentificatorText => Helper.Helper.SelectedIdentificatorText;
		#endregion
	}
}
