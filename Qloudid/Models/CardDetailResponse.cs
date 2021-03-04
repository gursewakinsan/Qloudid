﻿namespace Qloudid.Models
{
	public class CardDetailResponse
	{
		public int id { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(name_on_card, 0).ToUpper();
		public string name_on_card { get; set; }
		public string card_number { get; set; }
		public int company_id { get; set; }
		public string card_cvv { get; set; }
		public string exp_month { get; set; }
		public string exp_year { get; set; }
		public string card_type { get; set; }
		public string card_number2 { get; set; }
	}
}