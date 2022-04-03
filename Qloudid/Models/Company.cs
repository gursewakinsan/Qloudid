using Xamarin.Forms;
using System.Collections.Generic;

namespace Qloudid.Models
{
	public class Company : BaseModel
	{
		public int id { get; set; }
		public string company_name { get; set; }
		public string profile_pic { get; set; }
		public string company_email { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(company_name, 0).ToUpper();
		public string AddressForSearch => $"{company_name}, {company_email}";

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

		private bool isPersonal;
		public bool IsPersonal
		{
			get { return isPersonal; }
			set
			{
				isPersonal = value;
				OnPropertyChanged("IsPersonal");
			}
		}

		private bool isBusiness;
		public bool IsBusiness
		{
			get { return isBusiness; }
			set
			{
				isBusiness = value;
				OnPropertyChanged("IsBusiness");
			}
		}
		public double CheckUnCheckColor => IsChecked ? 0.8 : 0.1;

		public bool IsSelectedEmployee { get; set; }

		private Color employeeCardBorderColor;
		public Color EmployeeCardBorderColor
		{
			get => employeeCardBorderColor;
			set
			{
				employeeCardBorderColor = value;
				OnPropertyChanged("EmployeeCardBorderColor");
			}
		}

		private double employeeNameTextOpacity;
		public double EmployeeNameTextOpacity
		{
			get => employeeNameTextOpacity;
			set
			{
				employeeNameTextOpacity = value;
				OnPropertyChanged("EmployeeNameTextOpacity");
			}
		}
	}

	public class CompanyInfo : List<Company>
	{
		public string Heading { get; set; }
		public List<Company> Company => this;
	}
}
