using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
    public interface IInvoiceService
    {
        Task<string> PayRentInvoiceAsync(Models.PayRentInvoiceRequest model);
    }
}
