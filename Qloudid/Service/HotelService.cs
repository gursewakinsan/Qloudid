using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

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
	}
}
