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

		public Task<int> AddCurrencyAsync(Models.AddCurrencyRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddCurrencyUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateHeadingAsync(Models.UpdateTextOrAvailabilityRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateHeadingUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateDescriptionAsync(Models.UpdateTextOrAvailabilityRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateDescriptionUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateNicknameAsync(Models.UpdateTextOrAvailabilityRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateNicknameUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> ChangeDescriptionAsync(Models.ChangeTextOrAvailabilityRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.ChangeDescriptionUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> ChangeListingAsync(Models.ChangeTextOrAvailabilityRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.ChangeListingUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.DisplayPhotosResponse>> DisplayPhotosAsync(Models.DisplayPhotosRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DisplayPhotosResponse>>(HttpWebRequest.Create(EndPointsList.DisplayPhotosUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> DeleteApartmentPhotoAsync(Models.DeleteApartmentPhotoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.DeleteApartmentPhotoUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddApartmentPhotosAsync(Models.AddApartmentPhotosRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddApartmentPhotosUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateBlockedAsync(Models.UpdateBlockedRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateBlockedUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateAvailableAsync(Models.UpdateAvailableRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateAvailableUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.GetBlockedDatesResponse>> GetBlockedDatesAsync(Models.GetBlockedDatesRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.GetBlockedDatesResponse>>(HttpWebRequest.Create(EndPointsList.GetBlockedDatesUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateSelectedBlockedAsync(Models.UpdateSelectedBlockedRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateSelectedBlockedUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateSelectedAvailableAsync(Models.UpdateSelectedBlockedRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateSelectedAvailableUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.GetSratedDetailResponse>> GetSratedDetailAsync(Models.GetSratedDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.GetSratedDetailResponse>>(HttpWebRequest.Create(EndPointsList.GetSratedDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> UpdateGetStartedPhotosAsync(Models.UpdateGetStartedPhotosRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.UpdateGetStartedPhotosUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> UpdateGetStartedDescriptionAsync(Models.UpdateGetStartedDescriptionRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.UpdateGetStartedDescriptionUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> UpdateTouristTaxAsync(Models.UpdateTouristTaxRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.UpdateTouristTaxUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> UpdateChannelPublishAsync(Models.UpdateChannelPublishRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.UpdateChannelPublishUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> PublishApartmentonChannelAsync(Models.PublishApartmentonChannelRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.PublishApartmentonChannelUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
