using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HalloXForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonKlickMich_Clicked(object sender, EventArgs e)
        {
            // Messagebox mit 1 Antwort
            // DisplayAlert("Nachricht", "Du hast den Button geklickt", "OK");

            // Messagebox mit 2 Antworten ("Ja/Nein")
            // var result = await DisplayAlert("Frage", "Mittagspause?", "Ja", "Nein");
            // await DisplayAlert("Antwort", $"Deine Antwort war: {result}", "Ok");

            // MessageBox mit mehreren Möglichkeiten
            string result = await DisplayActionSheet("Wähle deine Lieblingsfarbe", null, null, "Rot", "Gelb", "Grün", "Orange", "Blau");
            await DisplayAlert("Antwort", $"Deine Antwort war: {result}", "Ok");

        }
    }
}
