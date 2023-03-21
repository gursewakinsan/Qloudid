using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class IdentityCardListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public IdentityCardListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Back Command.
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
        }
        private void ExecuteBackCommand()
        {
            Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
        }
        #endregion
    }
}
