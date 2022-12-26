using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class HeadLineUpdatedPageViewModel : BaseViewModel
    {
		#region Constructor.
		public HeadLineUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Update Heading Command.
		private ICommand updateHeadingCommand;
		public ICommand UpdateHeadingCommand
		{
			get => updateHeadingCommand ?? (updateHeadingCommand = new Command(async () => await ExecuteUpdateHeadingCommand()));
		}
		private async Task ExecuteUpdateHeadingCommand()
		{
			if (string.IsNullOrWhiteSpace(Address.PropertyHeading))
				await Helper.Alert.DisplayAlert("Heading is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.UpdateHeadingAsync(new Models.UpdateTextOrAvailabilityRequest()
				{
					ApartmentId = Address.Id,
					PropertyNickName = Address.PropertyHeading
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Change Listing Command.
		private ICommand changeListingCommand;
		public ICommand ChangeListingCommand
		{
			get => changeListingCommand ?? (changeListingCommand = new Command(async () => await ExecuteChangeListingCommand()));
		}
		private async Task ExecuteChangeListingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.ChangeListingAsync(new Models.ChangeTextOrAvailabilityRequest()
			{
				ApartmentId = Address.Id,
			});
			await Navigation.PopAsync();
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
		#endregion
	}
}
