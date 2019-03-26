using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Layoutcontainer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var button = sender as Button;
            ////App.Current.Resources["MeinStyle"]
            //button.Style = (Style)Resources["NewStyle"];
            //gridRoot.Resources["specialButtonStyle"] = Resources["NewStyle"];

            // Wenn die Styles in der ContentPage sind:
            // Resources["currentLabelStyle"]= Resources["labelDarkStyle"]

            // Wenn die Styles in der App.Xaml sind:
            // App.Current.Resources["currentLabelStyle"]= App.Current.Resources["labelDarkStyle"]

            // Styles direkt setzen:
            // labelÜberschrift.Style = (Style)Resources["labelDarkStyle"]
            // labelUnterüberschrift.Style = (Style)Resources["labelDarkStyle"]
        }
    }
}
