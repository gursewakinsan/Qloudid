using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IHotelService
	{
		Task<Models.BookingDetailResponse> GetBookingDetailAsync(Models.BookingDetailRequest model);
		Task<Models.HotelCheckInResponse> VerifyCheckinDetailAsync(Models.HotelCheckInRequest model);
		Task<int> GetCheckedInHotelAsync(Models.CheckedInHotelRequest model);
		Task<int> VerifyDependentChekInAsync(Models.VerifyDependent model);
		Task<int> ConfirmUserInvitationInfoAsync(Models.ConfirmUserInvitationInfoRequest model);
		Task<int> CheckOutGuestAsync(Models.CheckOutGuestRequest model);


		////Noffa App
		Task<int> GetFrontDeskCheckedInHotelAsync(Models.FrontDeskCheckedInHotelRequest model);
	}
}
