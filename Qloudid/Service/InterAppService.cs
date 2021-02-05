using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class InterAppService : IInterAppService
	{
		public Task<Models.InterAppResponse> VerifyInterAppPasswordAsync(Models.InterAppRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.InterAppResponse>(HttpWebRequest.Create(EndPointsList.VerifyInterAppPasswordUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
