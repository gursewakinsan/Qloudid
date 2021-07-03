using Xamarin.Forms;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class SelectHomeOrPickUpPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SelectHomeOrPickUpPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			BindList();
		}
		#endregion

		#region Bind List.
		void BindList()
		{
			var list = new List<Models.SelectHomeOrPickUpInfo>();
			Models.SelectHomeOrPickUpInfo listHomeOrPickup = new Models.SelectHomeOrPickUpInfo();
			listHomeOrPickup.SelectHomeOrPickUpAddress.Add(new Models.SelectHomeOrPickUp()
			{
				Id = 0,
				HeadingAddress = "Home Delivery",
				SubHeadingAddress = "To be sent on delivery address",
				FirstLetterNameBg = Helper.Helper.ColorList[0]
			});

			listHomeOrPickup.SelectHomeOrPickUpAddress.Add(new Models.SelectHomeOrPickUp()
			{
				Id = 1,
				HeadingAddress = "Pick Up",
				SubHeadingAddress = "To be picked personally",
				FirstLetterNameBg = Helper.Helper.ColorList[1]
			});

			listHomeOrPickup.Heading = "Delivery Type";
			list.Add(listHomeOrPickup);

			ListOfSelectHomeOrPickUpAddress = list;
		}
		#endregion

		#region Properties.
		private List<Models.SelectHomeOrPickUpInfo> listOfSelectHomeOrPickUpAddress;
		public List<Models.SelectHomeOrPickUpInfo> ListOfSelectHomeOrPickUpAddress
		{
			get { return listOfSelectHomeOrPickUpAddress; }
			set
			{
				listOfSelectHomeOrPickUpAddress = value;
				OnPropertyChanged("ListOfSelectHomeOrPickUpAddress");
			}
		}
		#endregion
	}
}