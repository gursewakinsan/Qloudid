using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class CartService : ICartService
	{
		public Task<int> PayCartItemUsingAppAsync(Models.PayCartItemRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.PayCartItemUsingAppUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
