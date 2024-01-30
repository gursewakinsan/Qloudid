using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Service
{
    public class InvoiceService : IInvoiceService
    {
		public Task<string> PayRentInvoiceAsync(Models.PayRentInvoiceRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.PayRentInvoiceUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<string> ConfirmApartmentReservationAsync(Models.ConfirmApartmentReservationRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.ConfirmApartmentReservationUrl), string.Empty, model.ToJson());
				return res;
			});
		}

        public Task<Models.GetServiceInvoiceDetailResponse> GetServiceInvoiceDetailAsync(Models.GetServiceInvoiceDetailRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<Models.GetServiceInvoiceDetailResponse>(HttpWebRequest.Create(EndPointsList.GetServiceInvoiceDetailUrl), string.Empty, model.ToJson());
                return res;
            });
        }

        public Task<string> UpdateServiceInvoicePaymentDetailAsync(Models.UpdateServiceInvoicePaymentDetailRequest model)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(EndPointsList.UpdateServiceInvoicePaymentDetailUrl), string.Empty, model.ToJson());
                return res;
            });
        }
    }
}
