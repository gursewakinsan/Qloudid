using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NoIdentityCardAddedPageViewModel : BaseViewModel
    {
        #region Constructor.
        public NoIdentityCardAddedPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Add Identity card Command.
        private ICommand addIdentityCardCommand;
        public ICommand AddIdentityCardCommand
        {
            get => addIdentityCardCommand ?? (addIdentityCardCommand = new Command(async () => await ExecuteAddIdentityCardCommand()));
        }
        private async Task ExecuteAddIdentityCardCommand()
        {
            await Navigation.PushAsync(new Views.Identity.AddYourIdCardPage());
        }
        #endregion
    }
}
