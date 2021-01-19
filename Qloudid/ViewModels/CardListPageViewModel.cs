using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class CardListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CardListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get All Card Command.
		private ICommand getAllCardCommand;
		public ICommand GetAllCardCommand
		{
			get => getAllCardCommand ?? (getAllCardCommand = new Command(async () => await ExecuteGetAllCardCommand()));
		}
		private async Task ExecuteGetAllCardCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICreateAccountService service = new CreateAccountService();
			CardList = await service.GetAllCardDetailsAsync(new Models.GetCardDetailRequest() { UserId = Helper.Helper.UserId });
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add New Card Command.
		private ICommand addNewCardCommand;
		public ICommand AddNewCardCommand
		{
			get => addNewCardCommand ?? (addNewCardCommand = new Command(async () => await ExecuteAddNewCardCommand()));
		}
		private async Task ExecuteAddNewCardCommand()
		{
			Helper.Helper.IsAddMoreCard = true;
			await Navigation.PushAsync(new Views.AddNewCardPage());
		}
		#endregion

		#region Properties.
		private List<Models.GetCardDetailResponse> cardList;
		public List<Models.GetCardDetailResponse> CardList
		{
			get => cardList;
			set
			{
				cardList = value;
				OnPropertyChanged("CardList");
			}
		}
		#endregion
	}
}
