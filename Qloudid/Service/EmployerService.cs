using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class EmployerService : IEmployerService
	{
		public Task<int> EmployerRequestCountAsync(Models.EmployerRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.EmployerRequestCountUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.EmployerResponse>> EmployerRequestReceivedAsync(Models.EmployerRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.EmployerResponse>>(HttpWebRequest.Create(EndPointsList.EmployerRequestReceivedUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ApproveEmployerResponse> ApproveEmployerRequestAsync(Models.ApproveEmployerRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApproveEmployerResponse>(HttpWebRequest.Create(EndPointsList.ApproveEmployerRequestUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.RejectEmployerResponse> RejectEmployerRequestAsync(Models.RejectEmployerRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.RejectEmployerResponse>(HttpWebRequest.Create(EndPointsList.RejectEmployerRequestUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
