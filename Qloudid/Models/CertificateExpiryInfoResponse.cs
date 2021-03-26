namespace Qloudid.Models
{
	public class CertificateExpiryInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "expiry_date")]
		public string ExpiryDate { get; set; }
	}
}
