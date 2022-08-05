using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class BedroomService : IBedroomService
    {
		public Task<List<Models.BedroomDetailResponse>> BedroomDetailAsync(Models.BedroomDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.BedroomDetailResponse>>(HttpWebRequest.Create(EndPointsList.BedroomDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.UserDeliveryAddressesResponse>> UserDeliveryAddressesAsync(Models.UserDeliveryAddressesRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.UserDeliveryAddressesResponse>>(HttpWebRequest.Create(EndPointsList.UserDeliveryAddressesUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> AddBedroomAsync(Models.AddBedroomRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.AddBedroomUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> DeleteBedroomAsync(Models.DeleteBedroomRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.DeleteBedroomUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> AddBedToBedroomAsync(Models.AddBedToBedroomRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.AddBedToBedroomUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> DeleteBedroomBedInfoAsync(Models.DeleteBedroomBedInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.DeleteBedroomBedInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.BedType>> BedroomBedDetailAsync(Models.BedroomBedDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.BedType>>(HttpWebRequest.Create(EndPointsList.BedroomBedDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.BedTypeDetail>> BedTypeDetailAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.BedTypeDetail>>(HttpWebRequest.Create(EndPointsList.BedTypeDetailUrl), string.Empty, null);
				return res;
			});
		}

		public Task<string> UpdateBedTypeInfoAsync(Models.UpdateBedTypeInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.UpdateBedTypeInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}


