﻿using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class CardListForPayForDisheViewModel : BaseViewModel
	{
		#region Constructor.
		public CardListForPayForDisheViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Card List Command.
		private ICommand getCardListCommand;
		public ICommand GetCardListCommand
		{
			get => getCardListCommand ?? (getCardListCommand = new Command(async () => await ExecuteGetCardListCommand()));
		}
		private async Task ExecuteGetCardListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IPurchaseService service = new PurchaseService();
			List<Models.CardDetailResponse> response = await service.SubmitPurchaseDetailAsync(new Models.PurchaseDetail()
			{
				user_id = Helper.Helper.UserInfo.user_id,
				company_id = Helper.Helper.CompanyId,
				certificate_key = Helper.Helper.QrCertificateKey
			});
			if (response == null)
				await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
			else
				CardList = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.CardDetailResponse> cardList;
		public List<Models.CardDetailResponse> CardList
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