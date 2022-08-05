using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

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
			BathroomDetailList = await service.BathroomDetailAsync(new Models.BathroomDetailRequest()
			{
				AId = SelectedUserDeliveryAddress.Id
			});
			if (BathroomDetailList != null)
				Count = BathroomDetailList.Count;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.BathroomDetailResponse> bathroomDetailList;
		public List<Models.BathroomDetailResponse> BathroomDetailList
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
		#endregion
	}
}
