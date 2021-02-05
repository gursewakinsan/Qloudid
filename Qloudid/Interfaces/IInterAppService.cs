using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IInterAppService
	{
		Task<Models.InterAppResponse> VerifyInterAppPasswordAsync(Models.InterAppRequest model);
	}
}
