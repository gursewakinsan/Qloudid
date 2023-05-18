using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class CompanySearchPageViewModel : BaseViewModel
    {
        #region Constructor.
        public CompanySearchPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Company Search List Command.
        private ICommand companySearchListCommand;
        public ICommand CompanySearchListCommand
        {
            get => companySearchListCommand ?? (companySearchListCommand = new Command(async () => await ExecuteCompanySearchListCommand()));
        }
        private async Task ExecuteCompanySearchListCommand()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
                await Navigation.PushAsync(new Views.Property.CompanySearchListPage(SearchText));
        }
        #endregion

        #region Properties.
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
