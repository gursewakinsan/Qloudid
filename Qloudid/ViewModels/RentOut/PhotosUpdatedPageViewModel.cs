using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class PhotosUpdatedPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PhotosUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Display Photos Command.
		private ICommand displayPhotosCommand;
		public ICommand DisplayPhotosCommand
		{
			get => displayPhotosCommand ?? (displayPhotosCommand = new Command(async () => await ExecuteDisplayPhotosCommand()));
		}
		private async Task ExecuteDisplayPhotosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var response = await service.DisplayPhotosAsync(new Models.DisplayPhotosRequest()
			{
				ApartmentId = Address.Id,
			});
			if (response == null) response = new System.Collections.Generic.List<Models.DisplayPhotosResponse>();
			foreach (var item in response) item.IsAddNewPhoto = false;
			response.Add(new Models.DisplayPhotosResponse() { IsAddNewPhoto = true });
			DisplayPhotos = new ObservableCollection<Models.DisplayPhotosResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Delete Apartment Photo Command.
		private ICommand deleteApartmentPhotoCommand;
		public ICommand DeleteApartmentPhotoCommand
		{
			get => deleteApartmentPhotoCommand ?? (deleteApartmentPhotoCommand = new Command(async () => await ExecuteDeleteApartmentPhotoCommand()));
		}
		private async Task ExecuteDeleteApartmentPhotoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.DeleteApartmentPhotoAsync(new Models.DeleteApartmentPhotoRequest()
			{
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add Apartment Photos Command.
		private ICommand addApartmentPhotosCommand;
		public ICommand AddApartmentPhotosCommand
		{
			get => addApartmentPhotosCommand ?? (addApartmentPhotosCommand = new Command(async () => await ExecuteAddApartmentPhotosCommand()));
		}
		private async Task ExecuteAddApartmentPhotosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			string userImageInfo = Convert.ToBase64String(UserImageData);
			await service.AddApartmentPhotosAsync(new Models.AddApartmentPhotosRequest()
			{
				ApartmentId = Address.Id,
				UpdateInfo = userImageInfo
			});
			DisplayPhotosCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private ObservableCollection<Models.DisplayPhotosResponse> displayPhotos;
		public ObservableCollection<Models.DisplayPhotosResponse> DisplayPhotos
		{
			get => displayPhotos;
			set
			{
				displayPhotos = value;
				OnPropertyChanged("DisplayPhotos");
			}
		}

		public byte[] UserImageData { get; set; }
		#endregion
	}
}
