using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class VisitorsService : IVisitorsService
	{
		public Task<int> InformToEmployeeAsync(Models.InformToEmployeeRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.InformEmployeeUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
