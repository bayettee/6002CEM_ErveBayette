
using Microsoft.Maui.Controls;

namespace StudyGuide
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void OnGetStartedClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
