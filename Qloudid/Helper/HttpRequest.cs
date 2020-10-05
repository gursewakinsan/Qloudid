using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Qloudid.Helper
{
	public class HttpRequest
	{
		public static async Task<HttpRequestResponseStatus> PostRequest(string requestUrl, string requestData)
		{
			var responseStatus = new HttpRequestResponseStatus();
			using (var client = new HttpClient())
			{
				client.Timeout = TimeSpan.FromMinutes(3);
				//client.BaseAddress = new Uri(BaseReqUrl);
				HttpResponseMessage response = new HttpResponseMessage();
				//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpContent Content = new StringContent(requestData, Encoding.UTF8, "application/json");
				response = await client.PostAsync(requestUrl, Content).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					string result = await response.Content.ReadAsStringAsync();
					responseStatus = new HttpRequestResponseStatus() { Status = true, Result = result };
				}
			}
			return responseStatus;
		}
	}
}
public class HttpRequestResponseStatus
{
	public bool Status { get; set; }
	public string Message { get; set; }
	public string Result { get; set; }
	public System.Net.HttpStatusCode StatusCode { get; set; }
}
