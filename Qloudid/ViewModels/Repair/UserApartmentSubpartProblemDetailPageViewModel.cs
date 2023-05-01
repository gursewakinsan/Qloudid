using Xamarin.Forms;
using Qloudid.Service;
using Xamarin.Essentials;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class UserApartmentSubpartProblemDetailPageViewModel : BaseViewModel
    {
        #region Constructor.
        public UserApartmentSubpartProblemDetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Address = Helper.Helper.SelectedUserAddress;
        }
        #endregion

        #region User Apartment Subpart Problem Detail Command.
        private ICommand userApartmentSubpartProblemDetailCommand;
        public ICommand UserApartmentSubpartProblemDetailCommand
        {
            get => userApartmentSubpartProblemDetailCommand ?? (userApartmentSubpartProblemDetailCommand = new Command(async () => await ExecuteUserApartmentSubpartProblemDetailCommand()));
        }
        private async Task ExecuteUserApartmentSubpartProblemDetailCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IRepairService service = new RepairService();
            UserApartmentSubpartProblemDetailInfo = await service.UserApartmentSubpartProblemDetailAsync(new Models.UserApartmentSubpartProblemDetailRequest()
            {
                ApartmentId = Address.Id,
                TicketId = SelectedApartmentProblemDetail.TicketId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private Models.EditAddressResponse address;
        public Models.EditAddressResponse Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private Models.UserApartmentProblemDetailResponse selectedApartmentProblemDetail;
        public Models.UserApartmentProblemDetailResponse SelectedApartmentProblemDetail
        {
            get => selectedApartmentProblemDetail;
            set
            {
                selectedApartmentProblemDetail = value;
                OnPropertyChanged("SelectedApartmentProblemDetail");
            }
        }

        private List<Models.UserApartmentSubpartProblemDetailResponse> userApartmentSubpartProblemDetailInfo;
        public List<Models.UserApartmentSubpartProblemDetailResponse> UserApartmentSubpartProblemDetailInfo
        {
            get => userApartmentSubpartProblemDetailInfo;
            set
            {
                userApartmentSubpartProblemDetailInfo = value;
                OnPropertyChanged("UserApartmentSubpartProblemDetailInfo");
            }
        }
        #endregion
    }
}
