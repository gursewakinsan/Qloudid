using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class BedRoomDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public BedRoomDetailsPageViewModel(INavigation navigation)
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
				await service.DeleteBedroomBedInfoAsync(new Models.DeleteBedroomBedInfoRequest()
				{
					Id = SelectedBedroomDetail.Id
				});
				Count = Count - 1;
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
			await service.AddBedToBedroomAsync(new Models.AddBedToBedroomRequest()
			{
				Id = SelectedBedroomDetail.Id
			});
			Count = Count + 1;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
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
        public Models.BedroomDetailResponse SelectedBedroomDetail { get; set; }
        #endregion
    }
}
