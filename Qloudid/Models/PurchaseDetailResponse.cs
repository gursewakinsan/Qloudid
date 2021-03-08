using System;

namespace Qloudid.Models
{
	public class PurchaseDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "price")]
		public string Price { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
		public string CompanyName { get; set; }
		public int MyProperty { get; set; }
		public string DisplayPrice => $"-SEK{Price}";
		public string DisplayDate => DateTime.Today.Date.ToString("yyyy-MM-dd");
	}
}
