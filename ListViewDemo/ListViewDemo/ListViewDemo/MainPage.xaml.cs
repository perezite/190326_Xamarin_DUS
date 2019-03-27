using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private ObservableCollection<Person> data;
        private void GetData()
        {
            data = new ObservableCollection<Person>
            {
                new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
                new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=2000},
                new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=30000},
                new Person{Vorname="Franz",Nachname="Ose",Alter=40,Kontostand=-400},
                new Person{Vorname="Martha",Nachname="Pfahl",Alter=50,Kontostand=5550},
                new Person{Vorname="Klara",Nachname="Fall",Alter=60,Kontostand=12345},
                new Person{Vorname="Rainer",Nachname="Zufall",Alter=70,Kontostand=-12312300},
                new Person{Vorname="Frank N",Nachname="Stein",Alter=80,Kontostand=9865},
                new Person{Vorname="Anna",Nachname="Bolika",Alter=90,Kontostand=-999},
                new Person{Vorname="Albert",Nachname="Tross",Alter=100,Kontostand=100000000000},
            };
        }

        private void ButtonLaden_Clicked(object sender, EventArgs e)
        {
            GetData();
            listViewPersonen.ItemsSource = data;
        }

        private void ListViewPersonen_Refreshing(object sender, EventArgs e)
        {
            GetData();
            listViewPersonen.ItemsSource = data;

            // Variante 1:
            // listViewPersonen.IsRefreshing = false;

            // Variante 2:
            listViewPersonen.EndRefresh();
        }

        private void SearchBarVorname_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewPersonen.ItemsSource = data.Where(x => x.Vorname.ToLower().StartsWith(e.NewTextValue.ToLower())).ToArray();
        }

        private void MenuItemInfo_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var p = item.BindingContext as Person;
            DisplayAlert("Info zur Person", $"{p.Vorname} {p.Nachname}: Alter:{p.Alter}, Kontostand:{p.Kontostand}€", "OK");
        }

        private void MenuItemDelete_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var p = item.BindingContext as Person;

            data.Remove(p);

            // Variante "hässlich"
            // listViewPersonen.ItemsSource = null;
            // listViewPersonen.ItemsSource = data;
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            DisplayAlert("Swipe", "❤❤❤❤", "OK");
        }
    }
}
