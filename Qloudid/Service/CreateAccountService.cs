using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

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
	}
}
