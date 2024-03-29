﻿using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class DependentService : IDependentService
	{
		public Task<List<Models.DependentResponse>> GetAllDependentAsync(Models.DependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentResponse>>(HttpWebRequest.Create(EndPointsList.GetAllDependentUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CheckSsnAsync(Models.CheckSsnRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CheckSsnUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CheckDependentSsnAsync(Models.CheckDependentSsnRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CheckDependentSsnUrl), string.Empty, request.ToJson());
				return res;
			});
		}
		
		public Task<int> AddDependentAsync(Models.AddDependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddDependentUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateDependentAsync(Models.UpdateDependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateDependentUrl), string.Empty, request.ToJson());
				return res;
			});
		}
		
		public Task<int> AddDependentProfileImagesAsync(Models.AddDependentProfileImagesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddDependentProfileImagesUrl), string.Empty, request.ToJson());
				return res;
			});
		}
		
		public Task<int> AddDependentImagesAsync(Models.AddDependentImagesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddDependentImagesUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AddDependentPassportAsync(Models.AddDependentPassportRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddDependentPassportUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CheckPassportAsync(Models.CheckPassportRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CheckPassportUrl), string.Empty, request.ToJson());
				return res;
			});
		}
		
		public Task<int> VerifyUserBookingExistsAsync(Models.CheckInDependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.VerifyUserBookingExistsUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateDependentCheckinIdsAsync(Models.UpdateDependentCheckinIdsRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateDependentCheckinIdsUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.DependentResponse>> DependentsListForCheckInAsync(Models.DependentsListForCheckInRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentResponse>>(HttpWebRequest.Create(EndPointsList.DependentsListForCheckinUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> GuestChildrenRemainingCountAsync(Models.GuestChildrenRemainingCountRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.GuestChildrenRemainingCountUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.DependentDetailResponse> DependentDetailAsync(Models.DependentDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.DependentDetailResponse>(HttpWebRequest.Create(EndPointsList.DependentDetailUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
