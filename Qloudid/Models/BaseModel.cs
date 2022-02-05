using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Qloudid.Models
{
	public class BaseModel : INotifyPropertyChanged
	{
		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}
