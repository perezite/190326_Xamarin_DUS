using NetworkShaker.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkShaker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShakePage : ContentPage, INetworkShakerPage
	{
		public ShakePage ()
		{
			InitializeComponent ();
		}

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            carouselViewShakeItems.ScrollTo(e.NewValue);
        }
    }
}