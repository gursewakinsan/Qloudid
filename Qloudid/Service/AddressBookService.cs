using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

		public Task<ObservableCollection<Models.ContactEmailDetail>> CheckValidEmailsAsync(ObservableCollection<Models.ContactEmailDetail> model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<ObservableCollection<Models.ContactEmailDetail>>(HttpWebRequest.Create(EndPointsList.CheckValidEmailsUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<ObservableCollection<Models.ContactPhoneNumberDetail>> CheckValidPhoneNumbersAsync(ObservableCollection<Models.ContactPhoneNumberDetail> model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<ObservableCollection<Models.ContactPhoneNumberDetail>>(HttpWebRequest.Create(EndPointsList.CheckValidPhoneNumbersUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.UserAddessBookContactDetailInfoResponse> UserAddessBookContactDetailInfoAsync(Models.UserAddessBookContactDetailInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.UserAddessBookContactDetailInfoResponse>(HttpWebRequest.Create(EndPointsList.UserAddessBookContactDetailInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}