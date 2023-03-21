using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddNewPassportIdPageViewModel : BaseViewModel
    {
        #region Constructor.
        public AddNewPassportIdPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Identity Card List Page Command.
        private ICommand identityCardListPageCommand;
        public ICommand IdentityCardListPageCommand
        {
            get => identityCardListPageCommand ?? (identityCardListPageCommand = new Command(async () => await ExecuteIdentityCardListPageCommand()));
        }
        private async Task ExecuteIdentityCardListPageCommand()
        {
            await Navigation.PushAsync(new Views.Identity.IdentityCardListPage());
        }
        #endregion
    }
}
