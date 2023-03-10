using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class PreCheckInGuestPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PreCheckInGuestPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			BindData();
		}
		#endregion

		#region Bind Data.
		void BindData()
		{
			List<TestItems> items = new List<TestItems>();
			items.Add(new TestItems()
			{
				IsAction =true,
				CircleBg =Color.FromHex("#F40000"),
				CategoryName ="Today"
			});
			items.Add(new TestItems()
			{
				IsAction = true,
				CircleBg = Color.FromHex("#F40000"),
				CategoryName = "2023-01-05"
			});
			items.Add(new TestItems()
			{
				IsAction = true,
				CircleBg = Color.FromHex("#F4B400"),
				CategoryName = "2023-01-12"
			});
			items.Add(new TestItems()
			{
				IsAction = true,
				CircleBg = Color.FromHex("#4A5192"),
				CategoryName = "2023-01-19"
			});
			items.Add(new TestItems()
			{
				IsAction = false,
				CircleBg = Color.FromHex("#4A5192"),
				CategoryName = "2023-01-26"
			});
			PreCheckInList = items;
		}
		#endregion

		#region Properties.
		private List<TestItems> preCheckInList;
		public List<TestItems> PreCheckInList
		{
			get => preCheckInList;
			set
			{
				preCheckInList = value;
				OnPropertyChanged("PreCheckInList");
			}
		}
		#endregion
	}

	public class TestItems
	{
		public int Id { get; set; }

		public string CategoryName { get; set; }

		public string Address { get; set; }

		public string PortNumber { get; set; }

		public int CleaningJobStatus { get; set; }

		public string Enc { get; set; }

		public Color CircleBg { get; set; }

		public bool IsAction { get; set; }

		public bool NotClean { get; set; } = false;

		public bool CleaningStart { get; set; } = false;

		public bool Cleaned { get; set; } = false;
	}
}
