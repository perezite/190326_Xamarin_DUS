using NavigationXForms.MD;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NavigationXForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Navigationpage hat kein Template -> Kapseln
            // MainPage = new NavigationPage(new MainPage());
            // MainPage = new TabbedPage_Demo();
            // MainPage = new CarouselPage_Demo();
            MainPage = new MD_Demo();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
