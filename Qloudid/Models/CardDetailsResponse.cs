namespace Qloudid.Models
{
	public class CardDetailsResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "card_number")]
		public string CardNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "card_cvv")]
		public int CardCvv { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "exp_month")]
		public string ExpMonth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "exp_year")]
		public int ExpYear { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_card")]
		public string NameOnCard { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_login_id")]
		public int UserLoginId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "card_type")]
		public string CardType { get; set; }
	}
}
