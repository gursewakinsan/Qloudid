using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IPurchaseService
	{
		Task<List<Models.Company>> GetCompanyAsync(Models.Profile model);
		Task<int> SubmitPurchaseDetailAsync(Models.PurchaseDetail model);
	}
}
