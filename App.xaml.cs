using StitchBookApp.Services;

namespace StitchBookApp
{
    public partial class App : Application
    {
        public App(HomePage homePage)
        {
            InitializeComponent();
            MainPage = new NavigationPage(homePage);
            //MainPage = homePage;
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new NavigationPage(new HomePage()));
        //}
    }
}