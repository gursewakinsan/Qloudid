using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

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
	}
}
