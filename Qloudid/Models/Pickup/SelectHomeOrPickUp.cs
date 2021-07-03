using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Qloudid.Models
{
	public class SelectHomeOrPickUp : INotifyPropertyChanged
	{
		public int Id { get; set; }
		public string HeadingAddress { get; set; }
		public string SubHeadingAddress { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(HeadingAddress, 0).ToUpper();
		
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

		private Color rowSelectedBg;
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

	public class SelectHomeOrPickUpInfo : List<SelectHomeOrPickUp>
	{
		public string Heading { get; set; }
		public List<SelectHomeOrPickUp> SelectHomeOrPickUpAddress => this;
	}
}


