using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface ICreateAccountService
	{
		Task<Models.CreateAccountResponse> CreateAccountAsync(Models.CreateAccount model);
		Task<Models.VerifyEmailOtpPinResponse> VerifyEmailOtpPinAsync(Models.VerifyEmailOtpPinRequest model);
		Task<Models.VerifyUserMobileResponse> VerifyUserMobileAsync(Models.VerifyUserMobileRequest model);
		Task<Models.VerifyEmailOtpPinResponse> VerifyPhoneOtpPinAsync(Models.VerifyEmailOtpPinRequest model);
		Task<int> AddIdentificatorAsync(Models.IdentificatorRequest model);
		Task<Models.GenerateCertificateResponse> GenerateCertificateAsync(Models.GenerateCertificateRequest model);
		Task<int> UploadAddIdentificatorImagesAsync(Models.AddIdentificatorImagesRequest model);
		Task<int> AddNewCardAsync(Models.AddNewCardRequest model);
		Task<int> AddDeliveryAddressAsync(Models.AddDeliveryAddressRequest model);
		Task<List<Models.CardDetailResponse>> GetAllCardDetailsAsync(Models.CardDetailRequest model);
		Task<int> SavePurchaseCardDetailsAsync(Models.AddNewPurchaseCardRequest model);
		Task<Models.CardDetailsResponse> GetCardDetailsByIdAsync(Models.CardDetailsRequest model);
		Task<int> UpdateCardPurchaseDetailAsync(Models.UpdateCardPurchaseDetail model);
		Task<Models.UserDeliveryInvoiceInfoResponse> UserDeliveryInvoiceInfoAsync(Models.UserDeliveryInvoiceInfoRequest model);
	}
}
