﻿using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IHotelService
	{
		Task<Models.BookingDetailResponse> GetBookingDetailAsync(Models.BookingDetailRequest model);
		Task<Models.HotelCheckInResponse> VerifyCheckinDetailAsync(Models.HotelCheckInRequest model);
	}
}
