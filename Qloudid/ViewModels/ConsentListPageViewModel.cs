using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class ConsentListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ConsentListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Employer Request Received Command.
		private ICommand employerRequestReceivedCommand;
		public ICommand EmployerRequestReceivedCommand
		{
			get => employerRequestReceivedCommand ?? (employerRequestReceivedCommand = new Command(async () => await ExecuteEmployerRequestReceivedCommand()));
		}
		private async Task ExecuteEmployerRequestReceivedCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IEmployerService service = new EmployerService();
			EmployerRequests = await service.EmployerRequestReceivedAsync(new Models.EmployerRequest()
			{ 
				UserId = Helper.Helper.UserId 
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Employer Details Command.
		private ICommand employerDetailsCommand;
		public ICommand EmployerDetailsCommand
		{
			get => employerDetailsCommand ?? (employerDetailsCommand = new Command(async () => await ExecuteEmployerDetailsCommand()));
		}
		private async Task ExecuteEmployerDetailsCommand()
		{
			await Navigation.PushAsync(new Views.EmployerDetailsPage(EmployerDetails));
		}
		#endregion

		#region Properties.
		private List<Models.EmployerResponse> employerRequests;
		public List<Models.EmployerResponse> EmployerRequests
		{
			get => employerRequests;
			set
			{
				employerRequests = value;
				OnPropertyChanged("EmployerRequests");
			}
		}

		public Models.EmployerResponse EmployerDetails { get; set; }
		#endregion
	}
}