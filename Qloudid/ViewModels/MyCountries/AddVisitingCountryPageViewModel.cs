using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddVisitingCountryPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddVisitingCountryPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		public string PassportNumber { get; set; }
		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; }
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; }

		public byte[] UserImageData1 { get; set; }
		public byte[] UserImageData2 { get; set; }
		#endregion
	}
}
