using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class NightlyPricingListPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NightlyPricingListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Nightly Pricing List Command.
		private ICommand nightlyPricingListCommand;
		public ICommand NightlyPricingListCommand
		{
			get => nightlyPricingListCommand ?? (nightlyPricingListCommand = new Command(async () => await ExecuteNightlyPricingListCommand()));
		}
		private async Task ExecuteNightlyPricingListCommand()
		{
			IsPageLoad = false;
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			NightlyPricingList = await service.NightlyPricingListAsync(new Models.NightlyPricingListRequest()
			{
				ApartmentId = Helper.Helper.SelectedUserDeliveryAddress.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
		}
		#endregion

		#region Remove Pricing Gap Command.
		private ICommand removePricingGapCommand;
		public ICommand RemovePricingGapCommand
		{
			get => removePricingGapCommand ?? (removePricingGapCommand = new Command<Models.NightlyPricingListResponse>(async (nightlyPricing) => await ExecuteRemovePricingGapCommand(nightlyPricing)));
		}
		private async Task ExecuteRemovePricingGapCommand(Models.NightlyPricingListResponse nightlyPricing)
		{
			if (nightlyPricing.IsDeleted)
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.RemovePricingGapAsync(new Models.RemovePricingGapRequest()
				{
					Id = nightlyPricing.Id
				});
				NightlyPricingListCommand.Execute(null);
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				await Navigation.PushAsync(new Views.RentOut.UpdateNightlyPricingPage(nightlyPricing));
		}
		#endregion

		#region Add Pricing Command.
		private ICommand addPricingCommand;
		public ICommand AddPricingCommand
		{
			get => addPricingCommand ?? (addPricingCommand = new Command(async () => await ExecuteAddPricingCommand()));
		}
		private async Task ExecuteAddPricingCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.NightlyPricingPage());
		}
		#endregion

		#region Properties.
		private List<Models.NightlyPricingListResponse> nightlyPricingList;
		public List<Models.NightlyPricingListResponse> NightlyPricingList
		{
			get => nightlyPricingList;
			set
			{
				nightlyPricingList = value;
				OnPropertyChanged("NightlyPricingList");
			}
		}

		private bool isPageLoad = false;
		public bool IsPageLoad
		{
			get => isPageLoad;
			set
			{
				isPageLoad = value;
				OnPropertyChanged("IsPageLoad");
			}
		}
		#endregion
	}
}
