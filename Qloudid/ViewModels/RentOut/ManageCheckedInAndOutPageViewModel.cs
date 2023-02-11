using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class ManageCheckedInAndOutPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ManageCheckedInAndOutPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Apartment Checkedin Info Command.
		private ICommand apartmentCheckedinInfoCommand;
		public ICommand ApartmentCheckedinInfoCommand
		{
			get => apartmentCheckedinInfoCommand ?? (apartmentCheckedinInfoCommand = new Command(async () => await ExecuteApartmentCheckedinInfoCommand()));
		}
		private async Task ExecuteApartmentCheckedinInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			ApartmentCheckedinInfo = await service.ApartmentCheckedinInfoAsync(new Models.ApartmentCheckedinInfoRequest()
			{
				ApartmentId = Address.Id //28
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Apartment Checked Out Info Command.
		private ICommand apartmentCheckedOutInfoCommand;
		public ICommand ApartmentCheckedOutInfoCommand
		{
			get => apartmentCheckedOutInfoCommand ?? (apartmentCheckedOutInfoCommand = new Command(async () => await ExecuteApartmentCheckedOutInfoCommand()));
		}
		private async Task ExecuteApartmentCheckedOutInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			ApartmentCheckedOutInfo = await service.ApartmentCheckedOutInfoAsync(new Models.ApartmentCheckedinInfoRequest()
			{
				ApartmentId = Address.Id //28
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Selected Tab Command.
		private ICommand selectedTabCommand;
		public ICommand SelectedTabCommand
		{
			get => selectedTabCommand ?? (selectedTabCommand = new Command<string>((selectedTab) => ExecuteSelectedTabCommand(selectedTab)));
		}
		private void ExecuteSelectedTabCommand(string selectedTab)
		{
			switch (selectedTab)
			{
				case "CheckedIn":
					IsCheckedIn = true;
					ApartmentCheckedinInfoCommand.Execute(null);
					break;
				case "CheckedOut":
					IsCheckedIn = false;
					ApartmentCheckedOutInfoCommand.Execute(null);
					break;
			}
		}
		#endregion

		#region Properties.
		private List<Models.ApartmentCheckedinInfoResponse> apartmentCheckedinInfo;
		public List<Models.ApartmentCheckedinInfoResponse> ApartmentCheckedinInfo
		{
			get => apartmentCheckedinInfo;
			set
			{
				apartmentCheckedinInfo = value;
				OnPropertyChanged("ApartmentCheckedinInfo");
			}
		}

		private List<Models.ApartmentCheckedinInfoResponse> apartmentCheckedOutInfo;
		public List<Models.ApartmentCheckedinInfoResponse> ApartmentCheckedOutInfo
		{
			get => apartmentCheckedOutInfo;
			set
			{
				apartmentCheckedOutInfo = value;
				OnPropertyChanged("ApartmentCheckedOutInfo");
			}
		}

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

		public bool isCheckedIn;
		public bool IsCheckedIn
		{
			get => isCheckedIn;
			set
			{
				isCheckedIn = value;
				if (isCheckedIn)
				{
					CheckedInSelectedTab = true;
					CheckedOutSelectedTab = false;
				}
				else
				{
					CheckedInSelectedTab = false;
					CheckedOutSelectedTab = true;
				}
				OnPropertyChanged("IsCheckedIn");
			}
		}

		public bool checkedInSelectedTab;
		public bool CheckedInSelectedTab
		{
			get => checkedInSelectedTab;
			set
			{
				checkedInSelectedTab = value;
				OnPropertyChanged("CheckedInSelectedTab");
			}
		}

		public bool checkedOutSelectedTab;
		public bool CheckedOutSelectedTab
		{
			get => checkedOutSelectedTab;
			set
			{
				checkedOutSelectedTab = value;
				OnPropertyChanged("CheckedOutSelectedTab");
			}
		}
		#endregion
	}
}
