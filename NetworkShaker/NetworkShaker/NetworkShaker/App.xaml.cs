using NetworkShaker.Models.Interfaces;
using NetworkShaker.Services;
using NetworkShaker.Views;
using Plugin.Iconize;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NetworkShaker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());
            MainPage = new RootPage();
        }

        private MulticastService service;

        protected override void OnStart()
        {
            service = new MulticastService();
            service.StartService();
        }

        protected override void OnSleep()
        {
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
        }

        protected override void OnResume()
        {
            if (! Accelerometer.IsMonitoring)
                Accelerometer.Start(SensorSpeed.UI);
        }
    }
}
