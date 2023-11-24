
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace StudyGuide
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new WelcomePage());
        }
    }
}
