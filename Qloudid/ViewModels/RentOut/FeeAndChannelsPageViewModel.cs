using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class FeeAndChannelsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public FeeAndChannelsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Update Channel Publish Command.
		private ICommand updateChannelPublishCommand;
		public ICommand UpdateChannelPublishCommand
		{
			get => updateChannelPublishCommand ?? (updateChannelPublishCommand = new Command<string>(async (channelId) => await ExecuteUpdateChannelPublishCommand(channelId)));
		}
		private async Task ExecuteUpdateChannelPublishCommand(string channelId)
		{
			bool publishChannel = false;
			switch (channelId)
            {
				case "1":
					Address.PublishDstrictRent = !Address.PublishDstrictRent;
					publishChannel = Address.PublishDstrictRent;
					break;
				case "4":
					Address.PublishAirnub = !Address.PublishAirnub;
					publishChannel = Address.PublishAirnub;
					break;
				case "5":
					Address.PublishVrbo = !Address.PublishVrbo;
					publishChannel = Address.PublishVrbo;
					break;
				case "6":
					Address.PublishBooking = !Address.PublishBooking;
					publishChannel = Address.PublishBooking;
					break;
				case "7":
					Address.PublishTrip = !Address.PublishTrip;
					publishChannel = Address.PublishTrip;
					break;
				case "8":
					Address.PublishExptd = !Address.PublishExptd;
					publishChannel = Address.PublishExptd;
					break;
				case "9":
					Address.PublishTui = !Address.PublishTui;
					publishChannel = Address.PublishTui;
					break;
			}
            DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.UpdateChannelPublishAsync(new Models.UpdateChannelPublishRequest()
			{
				ApartmentId = Address.Id,
				ChannelId = Convert.ToInt32(channelId),
				PublishChannel = publishChannel ? 1 : 0
			});
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
