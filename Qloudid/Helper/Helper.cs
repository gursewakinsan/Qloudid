using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
		public static bool IsValid(string value)
		{
			return CheckEmail(value);
		}
		public static bool CheckEmail(string input)
		{
			return Regex.IsMatch(input,
		   @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
		   RegexOptions.IgnoreCase);
		}

		

		public static string QrCertificateKey { get; set; }
		public static Models.User UserInfo { get; set; }
		public static bool IsFirstTime { get; set; } = true;
		public static bool IsBack { get; set; } = true;
		public static string IpFromURL { get; set; }
		public static int UserId { get; set; }
		public static int CountryCode { get; set; }
		public static List<Models.Country> CountryList { get; set; }
		public static string SelectedIdentificatorText { get; set; }
	}
}