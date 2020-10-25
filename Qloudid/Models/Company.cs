using System.ComponentModel;

namespace Qloudid.Models
{
	public class Company : INotifyPropertyChanged
	{
		public int id { get; set; }
		public string company_name { get; set; }

		private bool isSelected;
		public bool IsSelected
		{
			get { return isSelected; }
			set
			{
				if (isSelected != value)
				{
					isSelected = value;
					OnPropertyChanged("IsSelected");
					OnPropertyChanged("IsSelectImageUrl");
				}
			}
		}
		public string IsSelectImageUrl => IsSelected ? "iconTickRed.png" : "iconTickGray.png";

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
