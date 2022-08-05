using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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
				BedroomBedDetailCommand.Execute(null);
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
			BedroomBedDetailCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Bedroom Bed Detail Command.
		private ICommand bedroomBedDetailCommand;
		public ICommand BedroomBedDetailCommand
		{
			get => bedroomBedDetailCommand ?? (bedroomBedDetailCommand = new Command(async () => await ExecuteBedroomBedDetailCommand()));
		}
		private async Task ExecuteBedroomBedDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();

			var response = await service.BedroomBedDetailAsync(new Models.BedroomBedDetailRequest()
			{
				Id = SelectedBedroomDetail.Id
			});
			foreach (var item in response)
			{
				item.SelectedBedType = item.BedTypeList.FirstOrDefault(x => x.BedType.Equals(item.BedInfo));
			}
			BedTypeList = response;
			Count = BedTypeList.Count;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Bed Type Info Command.
		private ICommand updateBedTypeInfoCommand;
		public ICommand UpdateBedTypeInfoCommand
		{
			get => updateBedTypeInfoCommand ?? (updateBedTypeInfoCommand = new Command(async () => await ExecuteUpdateBedTypeInfoCommand()));
		}
		private async Task ExecuteUpdateBedTypeInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.UpdateBedTypeInfoAsync(new Models.UpdateBedTypeInfoRequest()
			{
				BedId  = BedId,
				BedInfo = BedInfo
			});
			BedroomBedDetailCommand.Execute(null);
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

		private List<Models.BedType> bedTypeList;
		public List<Models.BedType> BedTypeList
		{
			get => bedTypeList;
			set
			{
				bedTypeList = value;
				OnPropertyChanged("BedTypeList");
			}
		}

        public List<Models.BedTypeDetail> BedTypeDetailPickerList { get; set; }

        public int BedId { get; set; }
        public string BedInfo { get; set; }
        #endregion

    }
}
