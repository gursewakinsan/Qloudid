using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class BathroomsDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public BathroomsDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Minus Command.
		private ICommand minusCommand;
		public ICommand MinusCommand
		{
			get => minusCommand ?? (minusCommand = new Command(async () => await ExecuteMinusCommand()));
		}
		private async Task ExecuteMinusCommand()
		{
			if (Count > 1)
			{
				DependencyService.Get<IProgressBar>().Show();
				IBedroomService service = new BedroomService();
				await service.DeleteBathroomAsync(new Models.DeleteBathroomRequest()
				{
					AId = SelectedUserDeliveryAddress.Id
				});
				BathroomDetailCommand.Execute(null);
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Plus Command.
		private ICommand plusCommand;
		public ICommand PlusCommand
		{
			get => plusCommand ?? (plusCommand = new Command(async () => await ExecutePlusCommand()));
		}
		private async Task ExecutePlusCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.AddBathroomAsync(new Models.AddBathroomRequest()
			{
				AId = SelectedUserDeliveryAddress.Id
			});
			BathroomDetailCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Bathroom Detail Command.
		private ICommand bathroomDetailCommand;
		public ICommand BathroomDetailCommand
		{
			get => bathroomDetailCommand ?? (bathroomDetailCommand = new Command(async () => await ExecuteBathroomDetailCommand()));
		}
		private async Task ExecuteBathroomDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			var response  = await service.BathroomDetailAsync(new Models.BathroomDetailRequest()
			{
				AId = SelectedUserDeliveryAddress.Id
			});
			if (response != null)
				Count = response.Count;
			BathroomDetailList = new ObservableCollection<Models.BathroomDetailResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Bathroom Command.
		private ICommand updateBathroomCommand;
		public ICommand UpdateBathroomCommand
		{
			get => updateBathroomCommand ?? (updateBathroomCommand = new Command(async () => await ExecuteUpdateBathroomCommand()));
		}
		private async Task ExecuteUpdateBathroomCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.UpdateBathroomAsync(new Models.UpdateBathroomRequest()
			{
				AId = SelectedUserDeliveryAddress.Id,
				UpdateType = UpdateType,
				BathroomId = BathroomId,
				Bath = Bath
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Accessibility Command.
		private ICommand updateAccessibilityCommand;
		public ICommand UpdateAccessibilityCommand
		{
			get => updateAccessibilityCommand ?? (updateAccessibilityCommand = new Command(async () => await ExecuteUpdateAccessibilityCommand()));
		}
		private async Task ExecuteUpdateAccessibilityCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.UpdateAccessibilityAsync(new Models.UpdateAccessibilityRequest()
			{
				UpdateType = UpdateType,
				PrivateInfo = Bath,
				BathroomId = BathroomId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Overbath Command.
		private ICommand updateOverbathCommand;
		public ICommand UpdateOverbathCommand
		{
			get => updateOverbathCommand ?? (updateOverbathCommand = new Command(async () => await ExecuteUpdateOverbathCommand()));
		}
		private async Task ExecuteUpdateOverbathCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.UpdateOverbathAsync(new Models.UpdateOverbathRequest() 
			{
				BathroomId = BathroomId,
				OverBath = OverBath,
				StandAlone = StandAlone
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.BathroomDetailResponse> bathroomDetailList;
		public ObservableCollection<Models.BathroomDetailResponse> BathroomDetailList
		{
			get => bathroomDetailList;
			set
			{
				bathroomDetailList = value;
				OnPropertyChanged("BathroomDetailList");
			}
		}

		private int count;
		public int Count
		{
			get => count;
			set
			{
				count = value;
				OnPropertyChanged("Count");
			}
		}
		public Models.UserDeliveryAddressesResponse SelectedUserDeliveryAddress => Helper.Helper.SelectedUserDeliveryAddress;
        public int UpdateType { get; set; }
        public int BathroomId { get; set; }
        public int Bath { get; set; }
        public int OverBath { get; set; }
        public int StandAlone { get; set; }
        #endregion
    }
}
