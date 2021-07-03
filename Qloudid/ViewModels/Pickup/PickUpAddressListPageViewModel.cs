using Xamarin.Forms;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class PickUpAddressListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PickUpAddressListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			BindData();
		}
		#endregion

		#region Bind Data.
		void BindData()
		{
			var list = new List<Models.PickupAddressDetailInfo>();
			int index = 0;
			Models.PickupAddressDetailInfo listPickup = new Models.PickupAddressDetailInfo();
			foreach (var item in Helper.Helper.PickupAddressList)
			{
				item.FirstLetterNameBg = Helper.Helper.ColorList[index];
				index = index + 1;
				listPickup.Add(item);
			}
			listPickup.Heading = "Pick Up Address";
			list.Add(listPickup);

			ListOfPickupAddressDetail = list;
		}
		#endregion

		#region Properties.
		private List<Models.PickupAddressDetailInfo> listOfPickupAddressDetail;
		public List<Models.PickupAddressDetailInfo> ListOfPickupAddressDetail
		{
			get { return listOfPickupAddressDetail; }
			set
			{
				listOfPickupAddressDetail = value;
				OnPropertyChanged("ListOfPickupAddressDetail");
			}
		}
		#endregion
	}
}
