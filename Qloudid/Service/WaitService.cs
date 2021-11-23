using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class WaitService : IWaitService
	{
		public Task<int> AddGuestInfoAsync(Models.SubmitWaitListResturantDetail request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddGuestInfoUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
