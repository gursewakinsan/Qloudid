using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
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

		#region Close Command.
		private ICommand closeCommand;
		public ICommand CloseCommand
		{
			get => closeCommand ?? (closeCommand = new Command(async () => await ExecuteCloseCommand()));
		}
		private async Task ExecuteCloseCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion
	}
}