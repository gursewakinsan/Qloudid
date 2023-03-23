using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.SfCalendar.XForms;

namespace Qloudid.ViewModels
{
    public class KeyAvailablePageViewModel : BaseViewModel
	{
		#region Constructor.
		public KeyAvailablePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Display Key Photos Command.
		private ICommand displayKeyPhotosCommand;
		public ICommand DisplayKeyPhotosCommand
		{
			get => displayKeyPhotosCommand ?? (displayKeyPhotosCommand = new Command(async () => await ExecuteDisplayKeyPhotosCommand()));
		}
		private async Task ExecuteDisplayKeyPhotosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var response = await service.DisplayKeyPhotosAsync(new Models.DisplayKeyPhotosRequest()
			{
				ApartmentId = Address.Id,
			});
			if (response.Count <= 3)
				ListViewHeightRequest = 120;
			else if (response.Count <= 6)
                ListViewHeightRequest = 240;
			else if (response.Count <= 9)
                ListViewHeightRequest = 360;
			else if (response.Count <= 12)
                ListViewHeightRequest = 480;
			else
                ListViewHeightRequest = 540;
            DisplayKeyPhotos = new ObservableCollection<Models.DisplayKeyPhotosResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add Apartment Key Photos Command.
		private ICommand addApartmentKeyPhotosCommand;
		public ICommand AddApartmentPhotosCommand
		{
			get => addApartmentKeyPhotosCommand ?? (addApartmentKeyPhotosCommand = new Command(async () => await ExecuteAddApartmentKeyPhotosCommand()));
		}
		private async Task ExecuteAddApartmentKeyPhotosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			string userImageInfo = Convert.ToBase64String(UserImageData);
			await service.AddApartmentKeyPhotosAsync(new Models.AddApartmentKeyPhotosRequest()
			{
				ApartmentId = Address.Id,
				UpdateInfo = userImageInfo
			});
			DisplayKeyPhotosCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Apartment Key Info Command.
		private ICommand updateApartmentKeyInfoCommand;
		public ICommand UpdateApartmentKeyInfoCommand
		{
			get => updateApartmentKeyInfoCommand ?? (updateApartmentKeyInfoCommand = new Command(async () => await ExecuteUpdateApartmentKeyInfoCommand()));
		}
		private async Task ExecuteUpdateApartmentKeyInfoCommand()
		{
			if (Address.KeyAvailable && DisplayKeyPhotos.Count == 0)
				await Helper.Alert.DisplayAlert("Please add photo");
			else
			{
				IRentOutService service = new RentOutService();
				DependencyService.Get<IProgressBar>().Show();
				await service.UpdateApartmentKeyInfoAsync(new Models.UpdateApartmentKeyInfoRequest()
				{
					ApartmentId = Address.Id,
					KeyAvailable = Address.KeyAvailable,
					KeyDescription = Address.KeyDescription,
					TotalKeys = Address.TotalKeys
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Key Available Command.
		private ICommand keyAvailableCommand;
		public ICommand KeyAvailableCommand
		{
			get => keyAvailableCommand ?? (keyAvailableCommand = new Command(() => ExecuteKeyAvailableCommand()));
		}
		private void ExecuteKeyAvailableCommand()
		{
			Address.KeyAvailable = !Address.KeyAvailable;
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

		private ObservableCollection<Models.DisplayKeyPhotosResponse> displayKeyPhotos;
		public ObservableCollection<Models.DisplayKeyPhotosResponse> DisplayKeyPhotos
		{
			get => displayKeyPhotos;
			set
			{
				displayKeyPhotos = value;
				OnPropertyChanged("DisplayKeyPhotos");
			}
		}

        private double listViewHeightRequest;
        public double ListViewHeightRequest
        {
            get => listViewHeightRequest;
            set
            {
                listViewHeightRequest = value;
                OnPropertyChanged("ListViewHeightRequest");
            }
        }

        public byte[] UserImageData { get; set; }
		#endregion
	}
}