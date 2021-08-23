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
	}
}
