using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class RepairService : IRepairService
    {
		public Task<List<Models.UserApartmentTicketListResponse>> UserApartmentTicketListAsync(Models.UserApartmentTicketListRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.UserApartmentTicketListResponse>>(HttpWebRequest.Create(EndPointsList.UserApartmentTicketListUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
