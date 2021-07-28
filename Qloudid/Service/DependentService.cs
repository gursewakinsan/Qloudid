using System.Net;
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

		public Task<int> CheckSsnAsync(Models.AddDependentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CheckSsnUrl), string.Empty, request.ToJson());
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

		public Task<int> AddDependentImagesAsync(Models.AddDependentImagesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddDependentImagesUrl), string.Empty, request.ToJson());
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
	}
}
