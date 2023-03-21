using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class IdentityCardListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public IdentityCardListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            IdentityModelList = new List<IdentityModel>();
            IdentityModelList.Add(new IdentityModel()
            {
                Title = "National card",
                SubTitle = "Expires: 01/11 2028",
                IsChecked = false
            });
            IdentityModelList.Add(new IdentityModel()
            {
                Title = "Driver license",
                SubTitle = "Expires: 11/11 2024",
                IsChecked = false
            });
            IdentityModelList.Add(new IdentityModel()
            {
                Title = "Passport",
                SubTitle = "Expires: 11/11 2023",
                IsChecked = true
            });
        }
        #endregion

        #region Properties.
        public List<IdentityModel> IdentityModelList { get; set; }
        #endregion
    }

    public class IdentityModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsChecked { get; set; }
    }
}
