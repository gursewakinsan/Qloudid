using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class PurchaseService : IPurchaseService
	{
		public Task<List<Models.Company>> GetCompanyAsync(Models.Profile model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.Company>>(HttpWebRequest.Create(EndPointsList.ProfileDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.CardDetailResponse>> SubmitPurchaseDetailAsync(Models.PurchaseDetail model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CardDetailResponse>>(HttpWebRequest.Create(EndPointsList.PurchaseDetailUpdateUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
