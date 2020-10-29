namespace Qloudid.Helper
{
	public static class Helper
	{
		public static T FromJson<T>(this string jsonData)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
		}
		public static string ToJson(this object obj)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
		}
		public static string QrCertificateKey { get; set; }
		public static Models.User UserInfo { get; set; }
		public static bool IsFirstTime { get; set; } = true;
		public static bool IsBack { get; set; } = true;
		public static string IpFromURL { get; set; }
	}
}
