using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Qloudid.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public INavigation Navigation { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}