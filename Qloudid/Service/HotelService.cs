using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class HotelService : IHotelService
	{
		public Task<Models.BookingDetailResponse> GetBookingDetailAsync(Models.BookingDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.BookingDetailResponse>(HttpWebRequest.Create(EndPointsList.GetBookingDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.HotelCheckInResponse> VerifyCheckinDetailAsync(Models.HotelCheckInRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.HotelCheckInResponse>(HttpWebRequest.Create(EndPointsList.VerifyCheckinDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> GetCheckedInHotelAsync(Models.CheckedInHotelRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.GetCheckedInHotelUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> VerifyDependentChekInAsync(Models.VerifyDependent model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.VerifyDependentChekinUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> ConfirmUserInvitationInfoAsync(Models.ConfirmUserInvitationInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.ConfirmUserInvitationInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> CheckOutGuestAsync(Models.CheckOutGuestRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.CheckOutGuestUrl), string.Empty, model.ToJson());
				return res;
			});
		}
		

		//Noffa App
		public Task<int> GetFrontDeskCheckedInHotelAsync(Models.FrontDeskCheckedInHotelRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.GetFrontDeskCheckedInHotelUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		//Pre Check In
		public Task<List<Models.AdultsCheckedInListResponse>> AdultsCheckedInListAsync(Models.AdultsCheckedInListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AdultsCheckedInListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.AdultsCheckedInListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.DependentsCheckedInListResponse>> DependentsCheckedInListAsync(Models.DependentsCheckedInListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentsCheckedInListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.DependentsCheckedInListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> ResendInvitationAsync(Models.ResendInvitationRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.ResendInvitationUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CountryCodeListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CountryCodeUrl)), string.Empty, null);
				return res;
			});
		}

		public Task<int> PhoneIinviteAdultForCheckinAsync(Models.PhoneIinviteAdultForCheckinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.PhoneIinviteAdultForCheckinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> EmailIinviteAdultForCheckinAsync(Models.EmailIinviteAdultForCheckinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.EmailIinviteAdultForCheckinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.DependentsListForCheckinDstrictResponse>> DependentsListForCheckinDstrictAsync(Models.DependentsListForCheckinDstrictRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentsListForCheckinDstrictResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.DependentsListForCheckinDstrictUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AddDependentChekinAsync(Models.AddDependentChekinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddDependentChekinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
