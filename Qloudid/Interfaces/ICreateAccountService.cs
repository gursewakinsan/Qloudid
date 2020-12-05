using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ICreateAccountService
	{
		Task<Models.CreateAccountResponse> CreateAccountAsync(Models.CreateAccount model);
	}
}
