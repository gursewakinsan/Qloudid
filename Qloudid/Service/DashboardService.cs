using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
	public class DashboardService : IDashboardService
	{
		public Task<int> UpdateLoginIpAsync(string qrCode, Models.UpdateLoginIP ip)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateLoginIpUrl, qrCode)), string.Empty, ip.ToJson());
				return res;
			});
		}

		public Task<int> VerifyPasswordAsync(string qrCode, SetPassword password)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.VerifyPasswordUrl, qrCode)), string.Empty, password.ToJson());
				return res;
			});
		}

		public Task<int> ClearIpsAsync(string qrCode)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<int>(HttpWebRequest.Create(string.Format(EndPointsList.ClearIpsUrl, qrCode)));
				return res;
			});
		}

		public Task<int> UpdateLoginStatusAsync(string qrCode)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateLoginStatusUrl, qrCode)));
				return res;
			});
		}

		public Task<int> ClearCertificateAsync(Models.ClearCertificateRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.ClearCertificateUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AddressesResponse>> GetAddressesAsync(Models.AddressesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AddressesResponse>>(HttpWebRequest.Create(EndPointsList.ListAddressesUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.EditAddressResponse> GetAddressByIdAsync(Models.EditAddressRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.EditAddressResponse>(HttpWebRequest.Create(EndPointsList.UserAddressDetailUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateUserAddressAsync(Models.EditAddressResponse request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateUserAddressUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.EditAddressResponse> GetCompanyAddressByIdAsync(Models.EditAddressRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.EditAddressResponse>(HttpWebRequest.Create(EndPointsList.CompanyAddressDetailUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCompanyAddressAsync(Models.EditAddressResponse request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UpdateCompanyAddressUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
