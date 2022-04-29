using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Qloudid.Helper
{
	public static class Helper
	{
		public static T FromJson<T>(this string jsonData)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
		}
		public static string ToJson(this object obj)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
		}
		public static bool IsValid(string value)
		{
			return CheckEmail(value);
		}
		public static bool CheckEmail(string input)
		{
			return Regex.IsMatch(input,
		   @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
		   RegexOptions.IgnoreCase);
		}

		public static string GetLast(this string source, int tail_length)
		{
			if (tail_length >= source.Length)
				return source;
			return source.Substring(source.Length - tail_length);
		}

		public static string QrCertificateKey { get; set; }
		public static Models.User UserInfo { get; set; }
		public static bool IsFirstTime { get; set; }
		public static bool IsBack { get; set; } = true;
		public static string IpFromURL { get; set; }
		public static int UserId { get; set; }
		public static int HotelCheckedIn { get; set; }
		public static int CountryCode { get; set; }
		public static List<Models.Country> CountryList { get; set; }
		public static string SelectedIdentificatorText { get; set; }
		public static bool IsCameraPageImageClicked { get; set; } = false;
		public static string VerifyUserConsentClientId { get; set; }
		public static string UserMobileNumber { get; set; }
		public static int VerifyRestoreOtpPinWithMobileResult { get; set; }
		public static string UserEmail { get; set; }
		public static int CountDownWrongPassword { get; set; } = 0;
		public static bool IsThirdPartyWebLogin { get; set; } = false;
		public static bool IsAddMoreCard { get; set; }
		public static bool IsAddMoreAddresses { get; set; }
		public static Models.AddressesResponse DeliveryAddress { get; set; }
		public static int PurchaseIndex { get; set; }
		public static int UserOrCompanyAddress { get; set; }
		public static int UserOrCompanyAddressForInvoicing { get; set; }
		public static int CompanyId { get; set; }
		public static bool IsEditDeliveryAddressFromInvoicing { get; set; } = false;
		public static bool IsEditAddressFromYourSignature { get; set; } = false;
		public static Models.PurchaseDetailResponse PurchaseDetail { get; set; }
		public static Models.DeliveryAddressDetailResponse DeliveryAddressDetail { get; set; }
		public static Models.InvoiceAddressResponse InvoiceAddressDetail { get; set; }
		public static Models.CardDetailResponse CardDetail { get; set; }
		public static string HotelBookingId { get; set; } = string.Empty;
		public static bool IsHotelBookingFromQrScan { get; set; } = false;
		public static Models.BookingDetailResponse HotelBookingDetail { get; set; }
		public static bool IsHotelCheckInFromQrScan { get; set; } = false;
		public static bool IsHotelCheckInFromMobileBrowser { get; set; } = false;
		public static string HotelCheckinId { get; set; }
		public static string ClientIdForHotel { get; set; } = string.Empty;
		public static int GenerateCertificateIdentificatorValue { get; set; }
		public static int SelectedIdentificatorId { get; set; }
		public static List<Models.PickupAddressDetailResponse> PickupAddressList { get; set; }
		public static bool IsPickupAddress { get; set; } = false;
		public static bool IsPickupAddressAvailable { get; set; } = false;
		public static string QloudidPayButtonText { get; set; } = "Qloud ID Pay";
		public static Models.PickupAddressDetailResponse SelectedPickupAddress { get; set; }
		public static int DependentId { get; set; }
		public static bool IsFromWebDependent { get; set; } = false;
		public static bool IsFromScanQrDependent { get; set; } = false;
		public static string AppToAppName { get; set; }
		public static bool IsCashPayForDishe { get; set; } = false;
		public static bool IsScanQrPayForDishe { get; set; } = false;
		public static Models.PayOnRequest PayOnRequest { get; set; }
		public static Models.VerifyDependent VerifyDependentCheckInRequest { get; set; }
		public static int SelectedCardId { get; set; }
		public static int InvoiceAddressId { get; set; }
		public static bool FromIWantToPayPage { get; set; } = false;
		public static int InvitedVisitorsMeetingId { get; set; }
		public static int VisitorProfileId { get; set; }

		public static bool IsPreCheckIn { get; set; } = false;
		public static Models.GetPreCheckinStatusResponse PreCheckinStatusInfo { get; set; }
		public static Models.GetUserActiveStatusResponse PreCheckInUserActiveStatusInfo { get; set; }

		public static Models.DependentDetailResponse DependentDetail { get; set; }
		public static int PreCheckinStatus { get; set; }


		public static string[] ColorList =
		{
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE",
			"#F29133", "#66D0C3", "#6830F1", "#9D3AF0", "#5785E5", "#5982F0", "#EB6559F", "#FA8D23", "#F4629D", "#662FFE"
		};
	}
}