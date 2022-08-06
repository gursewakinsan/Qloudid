using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BathroomsDetailsPage : ContentPage
    {
        BathroomsDetailsPageViewModel viewModel;
        public BathroomsDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BathroomsDetailsPageViewModel(this.Navigation);
        }

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BathroomDetailCommand.Execute(null);
        }
        #endregion

        #region Toilette & Sink Clicked.
        private void OnFrameToiletteAndSinkTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleToiletteAndSinkClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnStackLayoutToiletteAndSinkTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandleToiletteAndSinkClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnLabelToiletteAndSinkTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleToiletteAndSinkClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        async void HandleToiletteAndSinkClicked(Models.BathroomDetailResponse bathroom)
        {
            if (viewModel.BathroomDetailList.Count == 1 && bathroom.ToiletAndSink)
            {
                await DisplayAlert("", "Apartment must have one toilet and one bath atleast.", "Ok");
                return;
            }
            else
            {
                if (bathroom.ToiletAndSink)
                    viewModel.Bath = 0;
                else
                    viewModel.Bath = 1;
                viewModel.UpdateType = 1;
                viewModel.BathroomId = bathroom.Id;
                viewModel.UpdateBathroomCommand.Execute(null);
            }
            bathroom.ToiletAndSink = !bathroom.ToiletAndSink;
            if (viewModel.BathroomDetailList.Count > 1 && !bathroom.ToiletAndSink && !bathroom.Shower && !bathroom.Bath)
            {
                viewModel.BathroomDetailCommand.Execute(null);
            }
        }
        #endregion

        #region Shower Clicked.
        private void OnFrameShowerTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleShowerClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnStackLayoutShowerTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandleShowerClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnLabelShowerTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleShowerClicked(control.BindingContext as Models.BathroomDetailResponse);
        }
        void HandleShowerClicked(Models.BathroomDetailResponse bathroom)
        {
            if (bathroom.Shower)
                viewModel.Bath = 0;
            else
                viewModel.Bath = 1;

            viewModel.UpdateType = 3;
            viewModel.BathroomId = bathroom.Id;
            
            viewModel.UpdateBathroomCommand.Execute(null);
            bathroom.Shower = !bathroom.Shower;

            if (viewModel.BathroomDetailList.Count > 1 && !bathroom.ToiletAndSink && !bathroom.Shower && !bathroom.Bath)
            {
                viewModel.BathroomDetailCommand.Execute(null);
            }
            
        }
        #endregion

        #region Bathtub Clicked.
        private void OnFrameBathtubTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleBathtubClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnStackLayoutBathtubTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandleBathtubClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnLabelBathtubTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleBathtubClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        async void HandleBathtubClicked(Models.BathroomDetailResponse bathroom)
        {
            if (viewModel.BathroomDetailList.Count == 1 && bathroom.Bath)
            {
                await DisplayAlert("", "Apartment must have one toilet and one bath atleast.", "Ok");
                return;
            }
            else
            {
                if (bathroom.Bath)
                    viewModel.Bath = 0;
                else
                    viewModel.Bath = 1;

                viewModel.UpdateType = 2;
                viewModel.BathroomId = bathroom.Id;
                
                viewModel.UpdateBathroomCommand.Execute(null);
            }
            bathroom.Bath = !bathroom.Bath;
            if (viewModel.BathroomDetailList.Count > 1 && !bathroom.ToiletAndSink && !bathroom.Shower && !bathroom.Bath)
            {
                viewModel.BathroomDetailCommand.Execute(null);
            }
            
        }
        #endregion

        #region Standalone Clicked.
        private void OnLabelStandaloneTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleStandaloneClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnButtonStandaloneTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            HandleStandaloneClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        void HandleStandaloneClicked(Models.BathroomDetailResponse bathroom)
        {
            if (!bathroom.StandaloneShower)
            {
                bathroom.StandaloneShower = !bathroom.StandaloneShower;
                bathroom.OverBathShower = false;
                viewModel.BathroomId = bathroom.Id;
                viewModel.OverBath = 0;
                viewModel.StandAlone = 1;
                viewModel.UpdateOverbathCommand.Execute(null);
            }
        }
        #endregion

        #region An over-bath shower Clicked.
        private void OnLabelAnOverBathShowerTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleAnOverBathShowerClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnButtonAnOverBathShowerTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            HandleAnOverBathShowerClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        void HandleAnOverBathShowerClicked(Models.BathroomDetailResponse bathroom)
        {
            if (!bathroom.OverBathShower)
            {
                bathroom.OverBathShower = !bathroom.OverBathShower;
                bathroom.StandaloneShower = false;
                viewModel.BathroomId = bathroom.Id;
                viewModel.OverBath = 1;
                viewModel.StandAlone = 0;
                viewModel.UpdateOverbathCommand.Execute(null);
            }
        }
        #endregion

        #region Private Clicked.
        private void OnFramePrivateTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleBathtubClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnStackLayoutPrivateTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandlePrivateClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnLabelPrivateTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandlePrivateClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        void HandlePrivateClicked(Models.BathroomDetailResponse bathroom)
        {
            if (bathroom.IsPrivate)
                viewModel.Bath = 0;
            else
                viewModel.Bath = 1;

            viewModel.UpdateType = 1;
            viewModel.BathroomId = bathroom.Id;

            bathroom.IsPrivate = !bathroom.IsPrivate;
            viewModel.UpdateAccessibilityCommand.Execute(null);
        }
        #endregion

        #region Ensuit Clicked.
        private void OnFrameEnsuitTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleEnsuitClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnStackLayoutEnsuitTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandleEnsuitClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnLabelEnsuitTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleEnsuitClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        void HandleEnsuitClicked(Models.BathroomDetailResponse bathroom)
        {
            if (bathroom.IsEnsuit)
                viewModel.Bath = 0;
            else
                viewModel.Bath = 1;

            viewModel.UpdateType = 2;
            viewModel.BathroomId = bathroom.Id;

            bathroom.IsEnsuit = !bathroom.IsEnsuit;
            viewModel.UpdateAccessibilityCommand.Execute(null);
        }
        #endregion

        #region Wheelchair accessible Clicked.
        private void OnFrameWheelchairAccessibleTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleWheelchairAccessibleClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnStackLayoutWheelchairAccessibleTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandleWheelchairAccessibleClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        private void OnLabelWheelchairAccessibleTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleWheelchairAccessibleClicked(control.BindingContext as Models.BathroomDetailResponse);
        }

        void HandleWheelchairAccessibleClicked(Models.BathroomDetailResponse bathroom)
        {
            if (bathroom.IsWheelchairAccessible)
                viewModel.Bath = 0;
            else
                viewModel.Bath = 1;

            viewModel.UpdateType = 3;
            viewModel.BathroomId = bathroom.Id;

            bathroom.IsWheelchairAccessible = !bathroom.IsWheelchairAccessible;
            viewModel.UpdateAccessibilityCommand.Execute(null);
        }
        #endregion
    }
}