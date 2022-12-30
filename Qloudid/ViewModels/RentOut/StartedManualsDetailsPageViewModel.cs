using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class StartedManualsDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public StartedManualsDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Yes/No Button Command.
		private ICommand yesNoButtonCommand;
		public ICommand YesNoButtonCommand
		{
			get => yesNoButtonCommand ?? (yesNoButtonCommand = new Command<string>((selectedButton) => ExecuteYesNoButtonCommand(selectedButton)));
		}
		private void ExecuteYesNoButtonCommand(string selectedButton)
		{
			switch (selectedButton)
			{
				case "Yes":
					YesButtonBg = Color.FromHex("#0C8CE8");
					NoButtonBg = Color.Transparent;
					SelectedStartedManuals.IsAvailable = true;
					break;
				case "No":
					YesButtonBg = Color.Transparent;
					NoButtonBg = Color.FromHex("#0C8CE8");
					SelectedStartedManuals.IsAvailable = false;
					break;
			}
		}
		#endregion

		#region Update Get Started Photos Command.
		private ICommand updateGetStartedPhotosCommand;
		public ICommand UpdateGetStartedPhotosCommand
		{
			get => updateGetStartedPhotosCommand ?? (updateGetStartedPhotosCommand = new Command(async () => await ExecuteUpdateGetStartedPhotosCommand()));
		}
		private async Task ExecuteUpdateGetStartedPhotosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			string userImageInfo = Convert.ToBase64String(UserImageData);
			await service.UpdateGetStartedPhotosAsync(new Models.UpdateGetStartedPhotosRequest()
			{
				GId = SelectedStartedManuals.Id,
				UpdateInfo = userImageInfo
			});
			SelectedStartedManuals.Images.Remove(SelectedStartedManuals.Images.FirstOrDefault(x => x.IsAddNewPhoto));
			SelectedStartedManuals.Images.Add(new Models.StartedImages() { IsAddNewPhoto = true });
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Get Started Description Command.
		private ICommand updateGetStartedDescriptionCommand;
		public ICommand UpdateGetStartedDescriptionCommand
		{
			get => updateGetStartedDescriptionCommand ?? (updateGetStartedDescriptionCommand = new Command(async () => await ExecuteUpdateGetStartedDescriptionCommand()));
		}
		private async Task ExecuteUpdateGetStartedDescriptionCommand()
		{
			if (string.IsNullOrWhiteSpace(SelectedStartedManuals.GetStartedDescription))
				await Helper.Alert.DisplayAlert("Description is required.");
			else if (SelectedStartedManuals.IsCodeRequired && string.IsNullOrWhiteSpace(SelectedStartedManuals.GetStartedCode))
				await Helper.Alert.DisplayAlert("Code is required.");
			else if (SelectedStartedManuals.IsCodeRequired && string.IsNullOrWhiteSpace(SelectedStartedManuals.GetStartedPassword))
				await Helper.Alert.DisplayAlert("Password is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.UpdateGetStartedDescriptionAsync(new Models.UpdateGetStartedDescriptionRequest()
				{
					GId = SelectedStartedManuals.Id,
					PropertyNickname = SelectedStartedManuals.GetStartedDescription,
					GetStartedCode = SelectedStartedManuals.GetStartedCode,
					GetStartedPassword = SelectedStartedManuals.GetStartedPassword,
					IsAvailable = SelectedStartedManuals.IsAvailable ? 1 : 0
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
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

		private Models.GetSratedDetailResponse selectedStartedManuals;
		public Models.GetSratedDetailResponse SelectedStartedManuals
		{
			get => selectedStartedManuals;
			set
			{
				selectedStartedManuals = value;
				OnPropertyChanged("SelectedStartedManuals");
			}
		}

		private Color noButtonBg;
		public Color NoButtonBg
		{
			get => noButtonBg;
			set
			{
				noButtonBg = value;
				OnPropertyChanged("NoButtonBg");
			}
		}

		private Color yesButtonBg;
		public Color YesButtonBg
		{
			get => yesButtonBg;
			set
			{
				yesButtonBg = value;
				OnPropertyChanged("YesButtonBg");
			}
		}

		private double listViewHeightRequest;
		public double ListViewHeightRequest
		{
			get => listViewHeightRequest;
			set
			{
				listViewHeightRequest = value;
				OnPropertyChanged("ListViewHeightRequest");
			}
		}

		public byte[] UserImageData { get; set; }
		#endregion
	}
}
