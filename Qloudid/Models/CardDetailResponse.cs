using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace Qloudid.Models
{
	public class CardDetailResponse : INotifyPropertyChanged
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

		private string firstLetterNameBg;
		public string FirstLetterNameBg
		{
			get { return firstLetterNameBg; }
			set
			{
				firstLetterNameBg = value;
				OnPropertyChanged("FirstLetterNameBg");
			}
		}
		Color RandomColor()
		{
			Random randonGen = new Random();
			return Color.FromRgb(randonGen.Next(255), randonGen.Next(255),
			randonGen.Next(255));
		}

		private bool isSelect;
		public bool IsSelect
		{
			get { return isSelect; }
			set
			{
				if (isSelect != value)
				{
					isSelect = value;
					OnPropertyChanged("IsSelect");
					RowSelectedBg = IsSelect ? Color.FromHex("#E4FAF9") : Color.White;
					RowSelectedText = IsSelect ? Color.FromHex("#50B0C8") : Color.Black;
				}
			}
		}

		private Color rowSelectedBg = Color.White;
		public Color RowSelectedBg
		{
			get { return rowSelectedBg; }
			set
			{
				rowSelectedBg = value;
				OnPropertyChanged("RowSelectedBg");
			}
		}

		private Color rowSelectedText = Color.Black;
		public Color RowSelectedText
		{
			get { return rowSelectedText; }
			set
			{
				rowSelectedText = value;
				OnPropertyChanged("RowSelectedText");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
