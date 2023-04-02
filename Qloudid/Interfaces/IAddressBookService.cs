using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IAddressBookService
    {
        Task<List<Models.UserAddressBookContactsResponse>> GetUserAddressBookContactsAsync(Models.UserAddressBookContactsRequest model);
        Task<int> AddNewContactInfoAsync(Models.AddContactInfoRequest model);
    }
}
