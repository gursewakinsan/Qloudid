using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class DescriptionUpdatedPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DescriptionUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Update Description Command.
		private ICommand updateDescriptionCommand;
		public ICommand UpdateDescriptionCommand
		{
			get => updateDescriptionCommand ?? (updateDescriptionCommand = new Command(async () => await ExecuteUpdateDescriptionCommand()));
		}
		private async Task ExecuteUpdateDescriptionCommand()
		{
			if (string.IsNullOrWhiteSpace(Address.ApartmentDescription))
				await Helper.Alert.DisplayAlert("Description is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.UpdateDescriptionAsync(new Models.UpdateTextOrAvailabilityRequest()
				{
					ApartmentId = Address.Id,
					PropertyNickName = Address.ApartmentDescription
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Change Description Command.
		private ICommand changeDescriptionCommand;
		public ICommand ChangeDescriptionCommand
		{
			get => changeDescriptionCommand ?? (changeDescriptionCommand = new Command(async () => await ExecuteChangeDescriptionCommand()));
		}
		private async Task ExecuteChangeDescriptionCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.ChangeDescriptionAsync(new Models.ChangeTextOrAvailabilityRequest()
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
