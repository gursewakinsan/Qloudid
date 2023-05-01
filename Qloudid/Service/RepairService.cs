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

		public Task<List<Models.UserApartmentProblemDetailResponse>> UserApartmentProblemDetailAsync(Models.UserApartmentProblemDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.UserApartmentProblemDetailResponse>>(HttpWebRequest.Create(EndPointsList.UserApartmentProblemDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.GetTicketSubTitleInfoResponse>> GetTicketSubTitleInfoAsync(Models.GetTicketSubTitleInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.GetTicketSubTitleInfoResponse>>(HttpWebRequest.Create(EndPointsList.GetTicketSubTitleInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> CreateUserApartmentTicketAsync(Models.CreateUserApartmentTicketRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CreateUserApartmentTicketUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> AddUserApartmentTicketImageAsync(Models.AddUserApartmentTicketImageRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.AddUserApartmentTicketImageUrl), string.Empty, model.ToJson());
				return res;
			});
		}

        public Task<List<Models.UserApartmentSubpartProblemDetailResponse>> UserApartmentSubpartProblemDetailAsync(Models.UserApartmentSubpartProblemDetailRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.UserApartmentSubpartProblemDetailResponse>>(HttpWebRequest.Create(EndPointsList.UserApartmentSubpartProblemDetailUrl), string.Empty, model.ToJson());
                return res;
            });
        }
    }
}