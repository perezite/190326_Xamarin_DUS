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
            MainPage = new ShakePage();
        }

        protected override void OnStart()
        {
        }
        public void SendMessage(string message)
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
