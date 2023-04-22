using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

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
				CategoryId = CategoryId
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
                CategoryId = CategoryId,
				
            });
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

        public int CategoryId { get; set; }
        #endregion
    }
}
