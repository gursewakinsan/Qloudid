using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class AddressBookService : IAddressBookService
	{
		public Task<List<Models.UserAddressBookContactsResponse>> GetUserAddressBookContactsAsync(Models.UserAddressBookContactsRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.UserAddressBookContactsResponse>>(HttpWebRequest.Create(EndPointsList.UserAddressBookContactDetailsUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddNewContactInfoAsync(Models.AddContactInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddNewContactInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
