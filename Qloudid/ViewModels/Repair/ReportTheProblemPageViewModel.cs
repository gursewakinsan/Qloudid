using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class ReportTheProblemPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ReportTheProblemPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Get Ticket Sub Title Info Command.
		private ICommand getTicketSubTitleInfoCommand;
		public ICommand GetTicketSubTitleInfoCommand
		{
			get => getTicketSubTitleInfoCommand ?? (getTicketSubTitleInfoCommand = new Command(async () => await ExecuteGetTicketSubTitleInfoCommand()));
		}
		private async Task ExecuteGetTicketSubTitleInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRepairService service = new RepairService();
			TicketSubTitleInfo = await service.GetTicketSubTitleInfoAsync(new Models.GetTicketSubTitleInfoRequest()
			{
				TicketId = SelectedApartmentProblemDetail.TicketId
			});
			if (TicketSubTitleInfo?.Count > 0)
				SelectedTicketSubTitleInfo = TicketSubTitleInfo[0];
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Report The Problem Command.
		private ICommand submitReportTheProblemCommand;
		public ICommand SubmitReportTheProblemCommand
		{
			get => submitReportTheProblemCommand ?? (submitReportTheProblemCommand = new Command(async () => await ExecuteSubmitReportTheProblemCommand()));
		}
		private async Task ExecuteSubmitReportTheProblemCommand()
		{
			if (string.IsNullOrWhiteSpace(ProblemDescription))
				await Helper.Alert.DisplayAlert("Description is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRepairService service = new RepairService();
				int response = await service.CreateUserApartmentTicketAsync(new Models.CreateUserApartmentTicketRequest()
				{
					ProblemDescription = ProblemDescription,
					TicketId = SelectedApartmentProblemDetail.TicketId,
					ApartmentId = Address.Id,
					SubticketId = SelectedTicketSubTitleInfo.Id
				});

				if (ImageDataInfo?.Count > 0)
				{
					foreach (var item in ImageDataInfo)
					{
						if (item.ImageId <= 9)
						{
							var imgResponse = await service.AddUserApartmentTicketImageAsync(new Models.AddUserApartmentTicketImageRequest()
							{
								ProblemId = response,
								ImageData = Convert.ToBase64String(item.ImageBytes)
							});
						}
					}
				}
				DependencyService.Get<IProgressBar>().Hide();
				Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			}
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private Models.UserApartmentProblemDetailResponse selectedApartmentProblemDetail;
		public Models.UserApartmentProblemDetailResponse SelectedApartmentProblemDetail
		{
			get => selectedApartmentProblemDetail;
			set
			{
				selectedApartmentProblemDetail = value;
				OnPropertyChanged("SelectedApartmentProblemDetail");
			}
		}

		private List<Models.GetTicketSubTitleInfoResponse> ticketSubTitleInfo;
		public List<Models.GetTicketSubTitleInfoResponse> TicketSubTitleInfo
		{
			get => ticketSubTitleInfo;
			set
			{
				ticketSubTitleInfo = value;
				OnPropertyChanged("TicketSubTitleInfo");
			}
		}

		private Models.GetTicketSubTitleInfoResponse selectedTicketSubTitleInfo;
		public Models.GetTicketSubTitleInfoResponse SelectedTicketSubTitleInfo
		{
			get => selectedTicketSubTitleInfo;
			set
			{
				selectedTicketSubTitleInfo = value;
				OnPropertyChanged("SelectedTicketSubTitleInfo");
			}
		}

		private string problemDescription;
		public string ProblemDescription
		{
			get => problemDescription;
			set
			{
				problemDescription = value;
				OnPropertyChanged("ProblemDescription");
			}
		}

		private bool image_1;
		public bool Image_1
		{
			get => image_1;
			set
			{
				image_1 = value;
				OnPropertyChanged("Image_1");
			}
		}

		private bool image_2;
		public bool Image_2
		{
			get => image_2;
			set
			{
				image_2 = value;
				OnPropertyChanged("Image_2");
			}
		}

		private bool image_3;
		public bool Image_3
		{
			get => image_3;
			set
			{
				image_3 = value;
				OnPropertyChanged("Image_3");
			}
		}

		private bool image_4;
		public bool Image_4
		{
			get => image_4;
			set
			{
				image_4 = value;
				OnPropertyChanged("Image_4");
			}
		}

		private bool image_5;
		public bool Image_5
		{
			get => image_5;
			set
			{
				image_5 = value;
				OnPropertyChanged("Image_5");
			}
		}

		private bool image_6;
		public bool Image_6
		{
			get => image_6;
			set
			{
				image_6 = value;
				OnPropertyChanged("Image_6");
			}
		}

		private bool image_7;
		public bool Image_7
		{
			get => image_7;
			set
			{
				image_7 = value;
				OnPropertyChanged("Image_7");
			}
		}

		private bool image_8;
		public bool Image_8
		{
			get => image_8;
			set
			{
				image_8 = value;
				OnPropertyChanged("Image_8");
			}
		}

		private bool image_9;
		public bool Image_9
		{
			get => image_9;
			set
			{
				image_9 = value;
				OnPropertyChanged("Image_9");
			}
		}
		public List<ImageData> ImageDataInfo { get; set; }
		#endregion
	}
}
public class ImageData
{
	public int ImageId { get; set; }
	public byte[] ImageBytes { get; set; }
}
