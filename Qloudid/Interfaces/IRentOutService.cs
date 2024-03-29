﻿using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IRentOutService
    {
        Task<List<Models.TimeInfoResponse>> TimeInfoAsync();
        Task<int> UpdateArrivalAsync(Models.UpdateArrivalRequest model);
        Task<List<Models.TimeHouseRulesInfoResponse>> TimeHouseRulesInfoAsync();
        Task<int> UpdateApartmentHouseRulesAsync(Models.UpdateApartmentHouseRulesRequest model);
        Task<int> UpdateCleeningAsync(Models.UpdateCleeningRequest model);
        Task<int> UpdateSecurityAsync(Models.UpdateSecurityRequest model);
        Task<List<Models.NightlyPricingListResponse>> NightlyPricingListAsync(Models.NightlyPricingListRequest model);
        Task<int> RemovePricingGapAsync(Models.RemovePricingGapRequest model);
        Task<Models.AddPricingPeriodResponse> AddPricingPeriodAsync(Models.AddPricingPeriodRequest model);
        Task<int> AddPricingAsync(Models.AddPricingRequest model);
        Task<int> GeneratePricingAsync(Models.GeneratePricingRequest model);
        Task<int> UpdatePricingAsync(Models.UpdatePricingRequest model);
        Task<int> DeletePricingUrlAsync(Models.DeletePricingRequest model);
        Task<int> AddCurrencyAsync(Models.AddCurrencyRequest model);
        Task<int> UpdateHeadingAsync(Models.UpdateTextOrAvailabilityRequest model);
        Task<int> UpdateDescriptionAsync(Models.UpdateTextOrAvailabilityRequest model);
        Task<int> UpdateNicknameAsync(Models.UpdateTextOrAvailabilityRequest model);
        Task<string> ChangeDescriptionAsync(Models.ChangeTextOrAvailabilityRequest model);
        Task<string> ChangeListingAsync(Models.ChangeTextOrAvailabilityRequest model);
        Task<List<Models.DisplayPhotosResponse>> DisplayPhotosAsync(Models.DisplayPhotosRequest model);
        Task<int> DeleteApartmentPhotoAsync(Models.DeleteApartmentPhotoRequest model);
        Task<int> AddApartmentPhotosAsync(Models.AddApartmentPhotosRequest model);
        Task<int> UpdateBlockedAsync(Models.UpdateBlockedRequest model);
        Task<int> UpdateAvailableAsync(Models.UpdateAvailableRequest model);
        Task<List<Models.GetBlockedDatesResponse>> GetBlockedDatesAsync(Models.GetBlockedDatesRequest model);
        Task<int> UpdateSelectedBlockedAsync(Models.UpdateSelectedBlockedRequest model);
        Task<int> UpdateSelectedAvailableAsync(Models.UpdateSelectedBlockedRequest model);
        Task<List<Models.GetSratedDetailResponse>> GetSratedDetailAsync(Models.GetSratedDetailRequest model);
        Task<string> UpdateGetStartedPhotosAsync(Models.UpdateGetStartedPhotosRequest model);
        Task<string> UpdateGetStartedDescriptionAsync(Models.UpdateGetStartedDescriptionRequest model);
        Task<string> UpdateTouristTaxAsync(Models.UpdateTouristTaxRequest model);
        Task<string> UpdateChannelPublishAsync(Models.UpdateChannelPublishRequest model);
        Task<string> PublishApartmentonChannelAsync(Models.PublishApartmentonChannelRequest model);
        Task<List<Models.ApartmentBookingListResponse>> ApartmentBookingListAsync(Models.ApartmentBookingListRequest model);
        Task<int> CheckAvailablityDatesAsync(Models.CheckAvailablityDatesRequest model);
        Task<Models.VerifyUserUsingPhoneDetailResponse> VerifyUserUsingPhoneDetailAsync(Models.VerifyUserUsingPhoneDetailRequest model);
        Task<int> SendBookingRequestInfoAsync(Models.SendBookingRequestInfoRequest model);
        Task<int> CheckPhoneInfoAsync(Models.CheckPhoneInfoRequest model);
        Task<int> CheckEmailInfoAsync(Models.CheckEmailInfoRequest model);
        Task<Models.CreateUserResponse> CreateUserAsync(Models.CreateUserRequest model);
        Task<string> AddIdentificatorRegisteredUserAsync(Models.AddIdentificatorRegisteredUserRequest model);
        Task<string> AddIdentificatorImagesRegisteredUserAsync(Models.AddIdentificatorImagesRegisteredUserRequest model);
        Task<int> SendBookingToNewUserAsync(Models.SendBookingToNewUserRequest model);
        Task<string> UpdateUserPersonalAddressAsync(Models.UpdateUserPersonalAddressRequest model);
        Task<string> SaveCompanyDetailsAsync(Models.SaveCompanyDetailsRequest model);
        Task<List<Models.ApartmentCheckedinInfoResponse>> ApartmentCheckedinInfoAsync(Models.ApartmentCheckedinInfoRequest model);
        Task<string> CheckoutApartmentGuestAsync(Models.CheckoutApartmentGuestRequest model);
        Task<List<Models.ApartmentCheckedinInfoResponse>> ApartmentCheckedOutInfoAsync(Models.ApartmentCheckedinInfoRequest model);
        Task<string> UpdateDamagedRentableInfoAsync(Models.UpdateDamagedRentableInfoRequest model);
        Task<List<Models.ApartmentCheckedOutCleeningHistoryResponse>> ApartmentCheckedOutCleeningHistoryAsync(Models.ApartmentCheckedOutCleeningHistoryRequest model);

        //Key
        Task<List<Models.DisplayKeyPhotosResponse>> DisplayKeyPhotosAsync(Models.DisplayKeyPhotosRequest model);
        Task<int> AddApartmentKeyPhotosAsync(Models.AddApartmentKeyPhotosRequest model);
        Task<int> UpdateApartmentKeyInfoAsync(Models.UpdateApartmentKeyInfoRequest model);
    }
}