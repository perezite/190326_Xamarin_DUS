using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Images
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var source = (UriImageSource)ImageSource.FromUri(new Uri("https://www.stevensegallery.com/300/300"));
            //source.CacheValidity = TimeSpan.FromMinutes(10);
            //imageBild.Source = source;

            // Ressource-ID: "Projektname.Ordnername.Dateiname.Extension"
            // imageBild.Source = ImageSource.FromResource("Images.Icons.Katze.png");

            // OnPlatform und OnIdiom
            //if(Device.RuntimePlatform == Device.Android)
            //{
            //    // ...
            //}

            //if(Device.Idiom == TargetIdiom.Tablet)
            //{

            //}
            
        }
    }
}
