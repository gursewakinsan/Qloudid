using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class CompanySearchListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public CompanySearchListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Company List Search Command.
        private ICommand companyListSearchCommand;
        public ICommand CompanyListSearchCommand
        {
            get => companyListSearchCommand ?? (companyListSearchCommand = new Command(async () => await ExecuteCompanyListSearchCommand()));
        }
        private async Task ExecuteCompanyListSearchCommand()
        {
            if (string.IsNullOrWhiteSpace(SearchText)) return;
            DependencyService.Get<IProgressBar>().Show();
            IPropertyService service = new PropertyService();
            CompanySearchList = await service.CompanyListSearchAsync(new Models.CompanyListSearchRequest()
            {
                Message = SearchText
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Add Landlord Command.
        private ICommand addLandlordCommand;
        public ICommand AddLandlordCommand
        {
            get => addLandlordCommand ?? (addLandlordCommand = new Command(async () => await ExecuteAddLandlordCommand()));
        }
        private async Task ExecuteAddLandlordCommand()
        {
            await Navigation.PushAsync(new Views.Property.AddLandlordPage());
        }
        #endregion

        #region Properties.
        private List<Models.CompanyListSearchResponse> companySearchList;
        public List<Models.CompanyListSearchResponse> CompanySearchList
        {
            get => companySearchList;
            set
            {
                companySearchList = value;
                OnPropertyChanged("CompanySearchList");
            }
        }

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        #endregion
    }
}