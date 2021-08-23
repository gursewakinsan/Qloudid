namespace Qloudid.Models
{
	public class CheckedInHotelRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_id")]
		public int CheckOutId { get; set; }
	}
}
