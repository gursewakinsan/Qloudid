using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class MyCountriesService : IMyCountriesService
    {
		public Task<int> CheckMobileNumberAsync(Models.CheckMobileNumberRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CheckMobileNumberUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> VerifyOtpDetailAsync(Models.VerifyOtpDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.VerifyOtpDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.CurrentCountryDetailResponse>> CurrentCountryDetailAsync(Models.CurrentCountryDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CurrentCountryDetailResponse>>(HttpWebRequest.Create(EndPointsList.CurrentCountryDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UserCountrySummaryAsync(Models.UserCountrySummaryRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UserCountrySummaryUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCountryAsync(Models.UpdateCountryRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateCountryUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
