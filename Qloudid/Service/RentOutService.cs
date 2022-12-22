using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class RentOutService : IRentOutService
    {
		public Task<List<Models.TimeInfoResponse>> TimeInfoAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TimeInfoResponse>>(HttpWebRequest.Create(EndPointsList.TimeInfoUrl), string.Empty, null);
				return res;
			});
		}

		public Task<int> UpdateArrivalAsync(Models.UpdateArrivalRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateArrivalUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.TimeHouseRulesInfoResponse>> TimeHouseRulesInfoAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TimeHouseRulesInfoResponse>>(HttpWebRequest.Create(EndPointsList.TimeHouseRulesInfoUrl), string.Empty, null);
				return res;
			});
		}

		public Task<int> UpdateApartmentHouseRulesAsync(Models.UpdateApartmentHouseRulesRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateApartmentHouseRulesUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCleeningAsync(Models.UpdateCleeningRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateCleeningUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateSecurityAsync(Models.UpdateSecurityRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateSecurityUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.NightlyPricingListResponse>> NightlyPricingListAsync(Models.NightlyPricingListRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.NightlyPricingListResponse>>(HttpWebRequest.Create(EndPointsList.ListPricingUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> RemovePricingGapAsync(Models.RemovePricingGapRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.RemovePricingGapUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.AddPricingPeriodResponse> AddPricingPeriodAsync(Models.AddPricingPeriodRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.AddPricingPeriodResponse>(HttpWebRequest.Create(EndPointsList.AddPricingPeriodUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddPricingAsync(Models.AddPricingRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddPricingUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> GeneratePricingAsync(Models.GeneratePricingRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.GeneratePricingUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdatePricingAsync(Models.UpdatePricingRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdatePricingUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> DeletePricingUrlAsync(Models.DeletePricingRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.DeletePricingUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
