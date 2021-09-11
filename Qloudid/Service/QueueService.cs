using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class QueueService : IQueueService
	{
		public Task<int> AddPersonToDesiredQueueAsync(Models.AddPersonToDesiredQueueRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddPersonToDesiredQueueUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
