using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class PreCheckInService : IPreCheckInService
	{
		public Task<Models.GetPreCheckinStatusResponse> GetPreCheckinStatusAsync(Models.GetPreCheckinStatusRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.GetPreCheckinStatusResponse>(HttpWebRequest.Create(EndPointsList.GetPreCheckinStatusUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.GetUserActiveStatusResponse> GetUserActiveStatusAsync(Models.GetUserActiveStatusRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.GetUserActiveStatusResponse>(HttpWebRequest.Create(EndPointsList.GetUserActiveStatusUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdatePreCheckinStatusAsync(Models.UpdatePreCheckinStatusRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdatePreCheckinStatusUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
