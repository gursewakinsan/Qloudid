using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class UploadDependentPassportPhotoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UploadDependentPassportPhotoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Helper.Helper.SelectedIdentificatorText = "Passport";
		}
		#endregion

		#region Upload Passport Image Command.
		private ICommand uploadPassportImageCommand;
		public ICommand UploadPassportImageCommand
		{
			get => uploadPassportImageCommand ?? (uploadPassportImageCommand = new Command(async () => await ExecuteUploadPassportImageCommand()));
		}
		private async Task ExecuteUploadPassportImageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Dependent.DependentListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Skip Upload Passport Images Command.
		private ICommand skipUploadPassportImageCommand;
		public ICommand SkipUploadPassportImageCommand
		{
			get => skipUploadPassportImageCommand ?? (skipUploadPassportImageCommand = new Command(async () => await ExecuteSkipUploadPassportImageCommand()));
		}
		private async Task ExecuteSkipUploadPassportImageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Dependent.DependentListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public Image Image1 { get; set; }
		public Image Image2 { get; set; }

		public byte[] CroppedImage1;

		public byte[] CroppedImage2;
		#endregion
	}
}
