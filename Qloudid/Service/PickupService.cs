﻿using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class PickupService : IPickupService
	{
		public Task<List<Models.PickupAddressDetailResponse>> PickupAddressDetailAsync(Models.PickupAddressDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.PickupAddressDetailResponse>>(HttpWebRequest.Create(EndPointsList.PickupAddressDetailUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.UpdatePickupDeliveryResponse> UpdatePickupDeliveryAsync(Models.UpdatePickupDeliveryRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.UpdatePickupDeliveryResponse>(HttpWebRequest.Create(EndPointsList.UpdatePickupDeliveryUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.UpdatePickupAddressResponse> UpdatePickupAddressAsync(Models.UpdatePickupAddressRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.UpdatePickupAddressResponse>(HttpWebRequest.Create(EndPointsList.UpdatePickupAddressUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
