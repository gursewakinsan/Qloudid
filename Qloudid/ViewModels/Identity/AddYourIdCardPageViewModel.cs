using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddYourIdCardPageViewModel : BaseViewModel
    {
        #region Constructor.
        public AddYourIdCardPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Add Passport Command.
        private ICommand addPassportCommand;
        public ICommand AddPassportCommand
        {
            get => addPassportCommand ?? (addPassportCommand = new Command(async () => await ExecuteAddPassportCommand()));
        }
        private async Task ExecuteAddPassportCommand()
        {
            await Navigation.PushAsync(new Views.Identity.AddNewPassportIdPage());
        }
        #endregion
    }
}
