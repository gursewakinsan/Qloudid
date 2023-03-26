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
            get => addPassportCommand ?? (addPassportCommand = new Command<string>(async (identificator) => await ExecuteAddPassportCommand(identificator)));
        }
        private async Task ExecuteAddPassportCommand(string identificator)
        {
            switch (identificator)
            {
                case "Passport":
                    Helper.Helper.SelectedIdentificatorText = "Passport";
                    break;
                case "DriverLicense":
                    Helper.Helper.SelectedIdentificatorText = "Driver license";
                    break;
                case "NationalCard":
                    Helper.Helper.SelectedIdentificatorText = "National card";
                    break;
            }
            await Navigation.PushAsync(new Views.Identity.AddNewPassportIdPage());
        }
        #endregion

        #region Add Passport Command.
        public Models.IdentificatorCountDetailResponse IdentificatorCountDetail;
        #endregion
    }
}
