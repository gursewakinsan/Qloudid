using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class BedroomService : IBedroomService
    {
		public Task<List<Models.BedroomDetailResponse>> BedroomDetailAsync(Models.BedroomDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.BedroomDetailResponse>>(HttpWebRequest.Create(EndPointsList.BedroomDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.UserDeliveryAddressesResponse>> UserDeliveryAddressesAsync(Models.UserDeliveryAddressesRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.UserDeliveryAddressesResponse>>(HttpWebRequest.Create(EndPointsList.UserDeliveryAddressesUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> AddBedroomAsync(Models.AddBedroomRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.AddBedroomUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> DeleteBedroomAsync(Models.DeleteBedroomRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.DeleteBedroomUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}

