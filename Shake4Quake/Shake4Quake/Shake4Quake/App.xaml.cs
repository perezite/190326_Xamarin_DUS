using Shake4Quake.Services;
using Shake4Quake.Views;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Shake4Quake
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new RootPage();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());

            service = new MulticastService();
        }
        private readonly MulticastService service;

        protected override void OnStart()
        {
            service.StartService();
        }
        protected override void OnSleep()
        {
            service.StoppService();
        }
        protected override void OnResume()
        {
            service.StartService();
        }
    }
}
