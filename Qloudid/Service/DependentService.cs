using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class DependentService : IDependentService
	{
		public Task<List<Models.DependentResponse>> GetAllDependentAsync(Models.DependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentResponse>>(HttpWebRequest.Create(EndPointsList.GetAllDependentUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> AddNewDependentAsync(Models.AddDependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.AddNewDependentUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
