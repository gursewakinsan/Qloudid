using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddNewPassportIdPageViewModel : BaseViewModel
    {
        #region Constructor.
        public AddNewPassportIdPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Identity Card List Page Command.
        private ICommand identityCardListPageCommand;
        public ICommand IdentityCardListPageCommand
        {
            get => identityCardListPageCommand ?? (identityCardListPageCommand = new Command(async () => await ExecuteIdentityCardListPageCommand()));
        }
        private async Task ExecuteIdentityCardListPageCommand()
        {
            await Navigation.PushAsync(new Views.Identity.IdentityCardListPage());
        }
        #endregion

        #region Properties.
        public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
        public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
        public DateTime SelectedIssueDate { get; set; }
        public DateTime BindExpiryMinimumDate => DateTime.Today;
        public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
        public DateTime SelectedExpiryDate { get; set; }
        public string IdentificatorTitle => Helper.Helper.SelectedIdentificatorText;
        #endregion
    }
}
