using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class PropertyService : IPropertyService
    {
        public Task<List<Models.CompanyListSearchResponse>> CompanyListSearchAsync(Models.CompanyListSearchRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.CompanyListSearchResponse>>(HttpWebRequest.Create(EndPointsList.CompanyListSearchUrl), string.Empty, model.ToJson());
                return res;
            });
        }

        public Task<List<Models.UserPropertyResponse>> UserPropertyAsync(Models.UserPropertyRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.UserPropertyResponse>>(HttpWebRequest.Create(EndPointsList.UserPropertyUrl), string.Empty, model.ToJson());
                return res;
            });
        }

        public Task<string> AddLandloardAsync(Models.AddLandloardRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.AddLandloardUrl), string.Empty, model.ToJson());
                return res;
            });
        }

        public Task<string> SendLandloardRequestAsync(Models.SendLandloardRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.SendRequestUrl), string.Empty, model.ToJson());
                return res;
            });
        }
    }
}
