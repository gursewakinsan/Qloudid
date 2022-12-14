using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class RentOutService : IRentOutService
    {
		public Task<List<Models.TimeInfoResponse>> TimeInfoAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TimeInfoResponse>>(HttpWebRequest.Create(EndPointsList.TimeInfoUrl), string.Empty, null);
				return res;
			});
		}

		public Task<int> UpdateArrivalAsync(Models.UpdateArrivalRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateArrivalUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
