﻿using System.Net;
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
	}
}