using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Qloudid.ViewModels
{
    public class AmenitiesSubCategoryDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AmenitiesSubCategoryDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Amenities Sub Category Detail Command.
		private ICommand amenitiesSubCategoryDetailCommand;
		public ICommand AmenitiesSubCategoryDetailCommand
		{
			get => amenitiesSubCategoryDetailCommand ?? (amenitiesSubCategoryDetailCommand = new Command(async () => await ExecuteAmenitiesSubCategoryDetailCommand()));
		}
		private async Task ExecuteAmenitiesSubCategoryDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			AmenitiesSubcategoryDetail = await service.AmenitiesSubcategoryDetailAsync(new Models.AmenitiesSubcategoryDetailRequest()
			{
				CategoryId = HomeRepairCategoryInfo.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
        #endregion

        #region Update Aminity Subcategory Command.
        private ICommand updateAminitySubcategoryCommand;
        public ICommand UpdateAminitySubcategoryCommand
        {
            get => updateAminitySubcategoryCommand ?? (updateAminitySubcategoryCommand = new Command(async () => await ExecuteUpdateAminitySubcategoryCommand()));
        }
        private async Task ExecuteUpdateAminitySubcategoryCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IBedroomService service = new BedroomService();
            int response = await service.UpdateAminitySubcategoryAsync(new Models.UpdateAminitySubcategoryRequest()
            {
                CategoryId = HomeRepairCategoryInfo.Id,
				UpdateType = UpdateType,
				IsAvailable = IsAvailable,
				AdvanceValues = AdvanceValues,
				UserAmenityId = UserAmenityId,
				WhoWillFixTheProblem = WhoWillFixTheProblem
            });
			AmenitiesSubcategoryDetail.FirstOrDefault(x => x.AdvanceValues == AdvanceValues).Count = response;
			DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.AmenitiesSubcategoryDetailResponse> amenitiesSubcategoryDetail;
		public List<Models.AmenitiesSubcategoryDetailResponse> AmenitiesSubcategoryDetail
		{
			get => amenitiesSubcategoryDetail;
			set
			{
				amenitiesSubcategoryDetail = value;
				OnPropertyChanged("AmenitiesSubcategoryDetail");
			}
		}

		private Models.HomeRepairCategoryInfoResponse homeRepairCategoryInfo;
		public Models.HomeRepairCategoryInfoResponse HomeRepairCategoryInfo
		{
			get => homeRepairCategoryInfo;
			set
			{
				homeRepairCategoryInfo = value;
				OnPropertyChanged("HomeRepairCategoryInfo");
			}
		}

        public int UpdateType { get; set; }
        public int IsAvailable { get; set; }
        public int AdvanceValues { get; set; }
        public int UserAmenityId { get; set; }
        public int WhoWillFixTheProblem { get; set; }
        #endregion
    }
}
