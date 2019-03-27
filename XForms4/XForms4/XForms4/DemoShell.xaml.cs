using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XForms4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DemoShell : Shell
	{
		public DemoShell ()
		{
			InitializeComponent ();
		}

        private async void ButtonRot_Clicked(object sender, EventArgs e)
        {
            // await GoToAsync(@"app://demo.com/rot",true);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            collectionViewDemo.ItemsSource = new List<Person>
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

        private void ButtonGetPersonenCarouselView_Clicked(object sender, EventArgs e)
        {
            carouselViewDemo.ItemsSource = new List<Person>
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

        private void SliderWert_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int index = Convert.ToInt32(e.NewValue);
            carouselViewDemo.ScrollTo(index,animate: true);
        }
    }
}