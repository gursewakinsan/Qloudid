using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class CreateAccountService : ICreateAccountService
	{
		public Task<Models.CreateAccountResponse> CreateAccountAsync(Models.CreateAccount model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.CreateAccountResponse>(HttpWebRequest.Create(EndPointsList.CreateNewAccountUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyEmailOtpPinResponse> VerifyEmailOtpPinAsync(Models.VerifyEmailOtpPinRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyEmailOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyEmailOtpPinUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyUserMobileResponse> VerifyUserMobileAsync(Models.VerifyUserMobileRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyUserMobileResponse>(HttpWebRequest.Create(EndPointsList.VerifyUserMobileUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyEmailOtpPinResponse> VerifyPhoneOtpPinAsync(Models.VerifyEmailOtpPinRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				//var res = RestClient.Post<Models.VerifyEmailOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyPhoneOtpPinUrl), string.Empty, model.ToJson());
				var res = RestClient.Post<Models.VerifyEmailOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyPhoneOtpPinWithIdUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddIdentificatorAsync(Models.IdentificatorRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddIdentificatorUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.GenerateCertificateResponse> GenerateCertificateAsync(Models.GenerateCertificateRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.GenerateCertificateResponse>(HttpWebRequest.Create(EndPointsList.GenerateCertificateUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UploadAddIdentificatorImagesAsync(Models.AddIdentificatorImagesRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UploadAddIdentificatorImagesUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddNewCardAsync(Models.AddNewCardRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddNewCardUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddDeliveryAddressAsync(Models.AddDeliveryAddressRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(Helper.Helper.IsAddMoreAddresses ? EndPointsList.AddNewAddressUrl : EndPointsList.AddDeliveryAddressUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<List<Models.CardDetailResponse>> GetAllCardDetailsAsync(Models.CardDetailRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CardDetailResponse>>(HttpWebRequest.Create(EndPointsList.ListCardDetailsUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> SavePurchaseCardDetailsAsync(Models.AddNewPurchaseCardRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.SavePurchaseCardDetailsUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.CardDetailsResponse> GetCardDetailsByIdAsync(Models.CardDetailsRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.CardDetailsResponse>(HttpWebRequest.Create(EndPointsList.CardDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCardPurchaseDetailAsync(Models.UpdateCardPurchaseDetail model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateCardPurchaseDetailUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.UserDeliveryInvoiceInfoResponse> UserDeliveryInvoiceInfoAsync(Models.UserDeliveryInvoiceInfoRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.UserDeliveryInvoiceInfoResponse>(HttpWebRequest.Create(EndPointsList.UserDeliveryInvoiceInfoUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCardAsync(Models.EditCardRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateCardUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> ConfirmPurchaseAsync(Models.ConfirmPurchaseRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.ConfirmPurchaseUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
