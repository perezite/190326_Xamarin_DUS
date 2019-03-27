using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Seite2());
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Xamarin.Forms.MessagingCenter.Subscribe<Slider, double>(this, MSG.SliderValueChanged, LabelAktualisieren);
        }

        private void LabelAktualisieren(Slider sender, double wert)
        {
            labelWertVomSlider.Text = wert.ToString();
        }
    }
}
