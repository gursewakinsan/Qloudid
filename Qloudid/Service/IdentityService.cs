using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class IdentityService : IIdentityService
	{
		public Task<Models.IdentificatorCountDetailResponse> IdentificatorCountDetailAsync(Models.IdentificatorCountDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.IdentificatorCountDetailResponse>(HttpWebRequest.Create(EndPointsList.IdentificatorCountDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.IdentificatorListResponse>> IdentificatorListAsync(Models.IdentificatorListRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.IdentificatorListResponse>>(HttpWebRequest.Create(EndPointsList.IdentificatorListUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}