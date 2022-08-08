using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
    public class AparmentService : IAparmentService
    {
		public Task<string> CheckinAparmentOwnerAsync(Models.CheckinAparmentOwnerRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.CheckinAparmentOwnerUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
