using System.Collections.Generic;
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

		//PreCheckIn
		Task<List<Models.AdultsCheckedInListResponse>> AdultsCheckedInListAsync(Models.AdultsCheckedInListRequest request);
		Task<List<Models.DependentsCheckedInListResponse>> DependentsCheckedInListAsync(Models.DependentsCheckedInListRequest request);
		Task<int> ResendInvitationAsync(Models.ResendInvitationRequest request);
		Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync();
		Task<int> PhoneIinviteAdultForCheckinAsync(Models.PhoneIinviteAdultForCheckinRequest request);
		Task<int> EmailIinviteAdultForCheckinAsync(Models.EmailIinviteAdultForCheckinRequest request);
		Task<List<Models.DependentsListForCheckinDstrictResponse>> DependentsListForCheckinDstrictAsync(Models.DependentsListForCheckinDstrictRequest request);
		Task<int> AddDependentChekinAsync(Models.AddDependentChekinRequest request);
	}
}
