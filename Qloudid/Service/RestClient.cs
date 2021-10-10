using System;
using System.IO;
using System.Net;
using System.Text;
using Qloudid.Helper;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public static class RestClient
	{
		public static T Get<T>(WebRequest request)
		{
			string result = string.Empty;
			request.Timeout = 40000;  //approx 40s
			request.ContentType = "application/json";
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
				WebResponse webResponse = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).Result;
				using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
				{
					result = streamReader.ReadToEnd();
				}
				webResponse.Close();
				webResponse.Dispose();
				var typ = typeof(T);
				if (
					typ == typeof(String)
					|| typ == typeof(float)
					|| typ == typeof(Decimal)
					|| typ == typeof(Int16)
					|| typ == typeof(Int32)
					|| typ == typeof(Int64)
				)
				{
					return (T)Convert.ChangeType(result, typeof(T), null);
				}
				return result.FromJson<T>();
			}
			catch (Exception ex)
			{
				return result.FromJson<T>();
			}
		}

		public static T Post<T>(WebRequest request, string token, string requestData = null)
		{
			//ServicePointManager.Expect100Continue = false;
			string result = string.Empty;
			request.Method = "POST";
			request.Timeout = 40000;  //approx 40s
			request.ContentType = "application/json";
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
			if (!string.IsNullOrEmpty(requestData))
			{
				UTF8Encoding encoder = new UTF8Encoding();
				byte[] data = encoder.GetBytes(requestData);
				Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null).Result.Write(data, 0, data.Length);
			}
			try
			{
				WebResponse webResponse = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).Result;
				using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
				{
					result = streamReader.ReadToEnd();
				}
				webResponse.Close();
				webResponse.Dispose();
				var typ = typeof(T);
				if (
					typ == typeof(String)
					|| typ == typeof(float)
					|| typ == typeof(Decimal)
					|| typ == typeof(Int16)
					|| typ == typeof(Int32)
					|| typ == typeof(Int64))
				{
					return (T)Convert.ChangeType(result, typeof(T), null);
				}
				return result.FromJson<T>();
			}
			catch (Exception ex)
			{
				return result.FromJson<T>();
			}
		}
	}
}
