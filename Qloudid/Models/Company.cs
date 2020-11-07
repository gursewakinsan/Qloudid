using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Qloudid.Models
{
	public class Company : INotifyPropertyChanged
	{
		public int id { get; set; }
		public string company_name { get; set; }
		public string company_email { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(company_name, 0).ToUpper();

		private bool isChecked;
		public bool IsChecked
		{
			get { return isChecked; }
			set
			{
				if (isChecked != value)
				{
					isChecked = value;
					OnPropertyChanged("IsChecked");
					OnPropertyChanged("CheckUnCheckColor");
				}
			}
		}
		public double CheckUnCheckColor => IsChecked ? 0.8 : 0.1;

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}

	public class CompanyInfo : List<Company>
	{
		public string Heading { get; set; }
		public List<Company> Company => this;
	}
}
