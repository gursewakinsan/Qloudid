namespace Qloudid.Models
{
	public class CertificateExpiryInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "certificate_key")]
		public string Certificatekey { get; set; }
	}
}
