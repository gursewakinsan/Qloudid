namespace Qloudid.Models
{
	public class GetCardDetailResponse
	{
		public int id { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(name_on_card, 0).ToUpper();
		public string name_on_card { get; set; }
		public string card_number { get; set; }
	}
}
