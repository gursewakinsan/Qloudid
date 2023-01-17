using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

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
	}
}
