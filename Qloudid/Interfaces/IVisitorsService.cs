using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IVisitorsService
	{
		Task<int> InformToEmployeeAsync(Models.InformToEmployeeRequest request);
	}
}
