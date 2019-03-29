using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DSUL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RootTabbedPage();
        }

        protected override void OnStart()
        {
            if(!Properties.ContainsKey("Notifications"))
                App.Current.Properties.Add("Notifications", true);
        }

        protected override void OnSleep()
        {
            // -> Erst hier werden die App.Properties gespeichert !!!
            // Speichern selbst anwerfen:
            // App.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
