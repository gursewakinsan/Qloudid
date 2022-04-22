using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Xamarin.Essentials;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class DependentsListForCheckinPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentsListForCheckinPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Dependents List For Checkin Dstrict Command.
		private ICommand dependentsListForCheckinDstrictCommand;
		public ICommand DependentsListForCheckinDstrictCommand
		{
			get => dependentsListForCheckinDstrictCommand ?? (dependentsListForCheckinDstrictCommand = new Command(async () => await ExecuteDependentsListForCheckinDstrictCommand()));
		}
		private async Task ExecuteDependentsListForCheckinDstrictCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.DependentsListForCheckinDstrictAsync(new Models.DependentsListForCheckinDstrictRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				UserId = Helper.Helper.UserId
			});
			DependentsListForCheckinInfo = new ObservableCollection<Models.DependentsListForCheckinDstrictResponse>(responses);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add Dependent Chekin Command.
		private ICommand addDependentChekinCommand;
		public ICommand AddDependentChekinCommand
		{
			get => addDependentChekinCommand ?? (addDependentChekinCommand = new Command(async () => await ExecuteAddDependentChekinCommand()));
		}
		private async Task ExecuteAddDependentChekinCommand()
		{
			//DependencyService.Get<IProgressBar>().Show();
			//IHotelService service = new HotelService();
			int childId = DependentsListForCheckinInfo.FirstOrDefault(x => x.IsSelect).Id;
			Models.VerifyPreCheckInDependentRequest request = new Models.VerifyPreCheckInDependentRequest()
			{
				SelectedVerifyDependentType = Models.VerifyDependentType.OnlyAdult,
				AdultId = childId
			};
			await Navigation.PushAsync(new Views.PreCheckIn.VerifyDependentPasswordPage(request));

			/*var id = await service.AddDependentChekinAsync(new Models.AddDependentChekinRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				ChildId = childId
			});
			Models.VerifyDependent verify = new Models.VerifyDependent()
			{
				Id = id,
				VerificationInfo = 1,
				CheckId = Helper.Helper.HotelCheckedIn,
			};
			Helper.Helper.VerifyDependentCheckInRequest = verify;
			await Navigation.PushAsync(new Views.PreCheckIn.VerifyDependentPasswordPage());
			DependencyService.Get<IProgressBar>().Hide();*/
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.DependentsListForCheckinDstrictResponse> dependentsListForCheckinInfo;
		public ObservableCollection<Models.DependentsListForCheckinDstrictResponse> DependentsListForCheckinInfo
		{
			get => dependentsListForCheckinInfo;
			set
			{
				dependentsListForCheckinInfo = value;
				OnPropertyChanged("DependentsListForCheckinInfo");
			}
		}
		//public Models.HotelCompleteInfoResponse HotelDetailsInfo => Helper.Helper.HotelDetails;
		#endregion
	}
}
