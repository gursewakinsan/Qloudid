using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.Interfaces
{
    public interface IAddressBookService
    {
        Task<List<Models.UserAddressBookContactsResponse>> GetUserAddressBookContactsAsync(Models.UserAddressBookContactsRequest model);
        Task<int> AddNewContactInfoAsync(Models.AddContactInfoRequest model);
        Task<ObservableCollection<Models.ContactEmailDetail>> CheckValidEmailsAsync(ObservableCollection<Models.ContactEmailDetail> model);
        Task<ObservableCollection<Models.ContactPhoneNumberDetail>> CheckValidPhoneNumbersAsync(ObservableCollection<Models.ContactPhoneNumberDetail> model);
        Task<List<Models.UserAddessBookContactDetailInfoResponse>> UserAddessBookContactDetailInfoAsync(Models.UserAddessBookContactDetailInfoRequest model);
    }
}
