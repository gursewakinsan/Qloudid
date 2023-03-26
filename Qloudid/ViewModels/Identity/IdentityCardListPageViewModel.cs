using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        #region Add Identity card Command.
        private ICommand addIdentityCardCommand;
        public ICommand AddIdentityCardCommand
        {
            get => addIdentityCardCommand ?? (addIdentityCardCommand = new Command(async () => await ExecuteAddIdentityCardCommand()));
        }
        private async Task ExecuteAddIdentityCardCommand()
        {
            if (IdentificatorCountDetail.TotalCount == 3) return;
            await Navigation.PushAsync(new Views.Identity.AddYourIdCardPage());
        }
        #endregion

        #region Identificator List Command.
        private ICommand identificatorListCommand;
        public ICommand IdentificatorListCommand
        {
            get => identificatorListCommand ?? (identificatorListCommand = new Command(async () => await ExecuteIdentificatorListCommand()));
        }
        private async Task ExecuteIdentificatorListCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IIdentityService service = new IdentityService();
            IdentificatorList = await service.IdentificatorListAsync(new Models.IdentificatorListRequest()
            {
                UserId = Helper.Helper.UserId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.IdentificatorListResponse> identificatorList;
        public List<Models.IdentificatorListResponse> IdentificatorList
        {
            get => identificatorList;
            set
            {
                identificatorList = value;
                OnPropertyChanged("IdentificatorList");
            }
        }
        public Models.IdentificatorCountDetailResponse IdentificatorCountDetail => Helper.Helper.IdentificatorCountDetail;
        #endregion
    }
}
