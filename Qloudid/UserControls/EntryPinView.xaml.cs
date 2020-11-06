using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPinView : ContentView
    {
        public static BindableProperty PinProperty = BindableProperty.Create("Pin", typeof(string), typeof(EntryPinView), defaultBindingMode: BindingMode.OneWayToSource);
        public string Pin
        {
            get => (string)GetValue(PinProperty);
            set => SetValue(PinProperty, value);
        }
        public EntryPinView()
        {
            InitializeComponent();
            Pin = string.Empty;

            PinEntry1.Text = PinEntry2.Text = PinEntry3.Text = string.Empty;
            PinEntry4.Text = PinEntry5.Text = PinEntry6.Text = string.Empty;

            PinEntry1.TextChanged += PinEntry1_TextChanged;
            PinEntry2.TextChanged += PinEntry2_TextChanged;
            PinEntry3.TextChanged += PinEntry3_TextChanged;
            PinEntry4.TextChanged += PinEntry4_TextChanged;
            PinEntry5.TextChanged += PinEntry5_TextChanged;
            PinEntry6.TextChanged += PinEntry6_TextChanged;

			PinEntry1.Focused += PinEntry1_Focused;
			PinEntry2.Focused += PinEntry2_Focused;
			PinEntry3.Focused += PinEntry3_Focused;
            PinEntry4.Focused += PinEntry4_Focused;
            PinEntry5.Focused += PinEntry5_Focused;
            PinEntry6.Focused += PinEntry6_Focused;

			PinEntry1.Unfocused += PinEntry1_Unfocused;
            PinEntry2.Unfocused += PinEntry2_Unfocused;
            PinEntry3.Unfocused += PinEntry3_Unfocused;
            PinEntry4.Unfocused += PinEntry4_Unfocused;
            PinEntry5.Unfocused += PinEntry5_Unfocused;
            PinEntry6.Unfocused += PinEntry6_Unfocused;
        }
		private void PinEntry1_Focused(object sender, FocusEventArgs e)
        {
            PinEntryFocused(1);
        }
        private void PinEntry2_Focused(object sender, FocusEventArgs e)
		{
            PinEntryFocused(2);
        }
        private void PinEntry3_Focused(object sender, FocusEventArgs e)
        {
            PinEntryFocused(3);
        }
        private void PinEntry4_Focused(object sender, FocusEventArgs e)
        {
            PinEntryFocused(4);
        }
        private void PinEntry5_Focused(object sender, FocusEventArgs e)
        {
            PinEntryFocused(5);
        }
        private void PinEntry6_Focused(object sender, FocusEventArgs e)
        {
            PinEntryFocused(6);
        }

        private void PinEntry1_Unfocused(object sender, FocusEventArgs e)
        {
            PinEntryUnFocused(1);
        }
        private void PinEntry2_Unfocused(object sender, FocusEventArgs e)
        {
            PinEntryUnFocused(2);
        }
        private void PinEntry3_Unfocused(object sender, FocusEventArgs e)
        {
            PinEntryUnFocused(3);
        }
        private void PinEntry4_Unfocused(object sender, FocusEventArgs e)
        {
            PinEntryUnFocused(4);
        }
        private void PinEntry5_Unfocused(object sender, FocusEventArgs e)
        {
            PinEntryUnFocused(5);
        }
        private void PinEntry6_Unfocused(object sender, FocusEventArgs e)
        {
            PinEntryUnFocused(6);
        }

        void PinEntryUnFocused(int entryFocused)
        {
            switch (entryFocused)
            {
                case 1:
                    BoxView1.BackgroundColor = Color.FromHex("#F8F8FA");
                    break;
                case 2:
                    BoxView2.BackgroundColor = Color.FromHex("#F8F8FA");
                    break;
                case 3:
                    BoxView3.BackgroundColor = Color.FromHex("#F8F8FA");
                    break;
                case 4:
                    BoxView4.BackgroundColor = Color.FromHex("#F8F8FA");
                    break;
                case 5:
                    BoxView5.BackgroundColor = Color.FromHex("#F8F8FA");
                    break;
                case 6:
                    BoxView6.BackgroundColor = Color.FromHex("#F8F8FA");
                    break;
            }
        }
        void PinEntryFocused(int entryFocused)
        {
            switch (entryFocused)
            {
                case 1:
                    BoxView1.BackgroundColor = Color.FromHex("#3623B7");
                    break;
                case 2:
                    BoxView2.BackgroundColor = Color.FromHex("#3623B7");
                    break;
                case 3:
                    BoxView3.BackgroundColor = Color.FromHex("#3623B7");
                    break;
                case 4:
                    BoxView4.BackgroundColor = Color.FromHex("#3623B7");
                    break;
                case 5:
                    BoxView5.BackgroundColor = Color.FromHex("#3623B7");
                    break;
                case 6:
                    BoxView6.BackgroundColor = Color.FromHex("#3623B7");
                    break;
            }
        }
        private void PinEntry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PinEntry1.Text.Length > 0) PinEntry2.Focus();
            Pin = PinEntry1.Text + PinEntry2.Text + PinEntry3.Text + PinEntry4.Text;
        }
        private void PinEntry2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PinEntry2.Text.Length > 0) PinEntry3.Focus();
            else PinEntry1.Focus();
            Pin = PinEntry1.Text + PinEntry2.Text + PinEntry3.Text + PinEntry4.Text;
        }
        private void PinEntry3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PinEntry3.Text.Length > 0) PinEntry4.Focus();
            else PinEntry2.Focus();
            Pin = PinEntry1.Text + PinEntry2.Text + PinEntry3.Text + PinEntry4.Text;
        }
        private void PinEntry4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PinEntry4.Text.Length > 0) PinEntry5.Focus();
            else PinEntry3.Focus();
            Pin = PinEntry1.Text + PinEntry2.Text + PinEntry3.Text + PinEntry4.Text + PinEntry5.Text + PinEntry6.Text;
        }
        private void PinEntry5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PinEntry5.Text.Length > 0) PinEntry6.Focus();
            else PinEntry4.Focus();
            Pin = PinEntry1.Text + PinEntry2.Text + PinEntry3.Text + PinEntry4.Text + PinEntry5.Text + PinEntry6.Text;
        }
        private void PinEntry6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PinEntry6.Text.Length > 0) PinEntry6.Unfocus();
            else PinEntry5.Focus();
            Pin = PinEntry1.Text + PinEntry2.Text + PinEntry3.Text + PinEntry4.Text + PinEntry5.Text + PinEntry6.Text;
        }
    }
}