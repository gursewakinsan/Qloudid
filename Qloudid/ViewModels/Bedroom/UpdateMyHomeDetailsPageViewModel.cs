using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class UpdateMyHomeDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public UpdateMyHomeDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Minus Command.
		private ICommand minusCommand;
		public ICommand MinusCommand
		{
			get => minusCommand ?? (minusCommand = new Command( async () => await ExecuteMinusCommand()));
		}
		private async Task ExecuteMinusCommand()
		{
			if (Count > 1)
			{
				DependencyService.Get<IProgressBar>().Show();
				IBedroomService service = new BedroomService();
				await service.DeleteBedroomAsync(new Models.DeleteBedroomRequest()
				{
					AId = SelectedUserDeliveryAddress.Id
				});
				BedroomDetailCommand.Execute(null);
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Plus Command.
		private ICommand plusCommand;
		public ICommand PlusCommand
		{
			get => plusCommand ?? (plusCommand = new Command(async () =>await ExecutePlusCommand()));
		}
		private async Task ExecutePlusCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			await service.AddBedroomAsync(new Models.AddBedroomRequest()
			{
				AId = SelectedUserDeliveryAddress.Id
			});
			BedroomDetailCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Bedroom Detail Command.
		private ICommand bedroomDetailCommand;
		public ICommand BedroomDetailCommand
		{
			get => bedroomDetailCommand ?? (bedroomDetailCommand = new Command(async () => await ExecuteBedroomDetailCommand()));
		}
		private async Task ExecuteBedroomDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			BedroomDetailList = await service.BedroomDetailAsync(new Models.BedroomDetailRequest()
			{
				AId = SelectedUserDeliveryAddress.Id
			});
			if (BedroomDetailList != null)
				Count = BedroomDetailList.Count;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.BedroomDetailResponse> bedroomDetailList;
		public List<Models.BedroomDetailResponse> BedroomDetailList
		{
			get => bedroomDetailList;
			set
			{
				bedroomDetailList = value;
				OnPropertyChanged("BedroomDetailList");
			}
		}

		private int count ;
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
