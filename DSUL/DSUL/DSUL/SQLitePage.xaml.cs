using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DSUL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SQLitePage : ContentPage
	{
		public SQLitePage ()
		{
			InitializeComponent ();

            // Init:
            string fullPath = string.Empty;
            if (Device.RuntimePlatform == Device.WPF)
                fullPath = "db.sqlite";
            else
                fullPath = Path.Combine(FileSystem.CacheDirectory, "db.sqlite");

            con = new SQLiteAsyncConnection(fullPath); // Erstellt wenns nicht vorhanden ist oder öffnet es wenn es bereits existiert
            // Nur beim ersten starten relevant:
            con.CreateTableAsync<Person>(); // Wenn die Tabelle bereits existiert, passiert nichts
		}
        SQLiteAsyncConnection con;


        private async void ButtonEinfügen_Clicked(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Vorname = entryName.Text;
            p.Nachname = "Mustermann";
            p.Alter = 10;
            p.Kontostand = 100;

            await con.InsertAsync(p);
            await DisplayAlert("Message", "Person wurde erfolgreich gespeichert !", "OK");
        }

        private async void ListViewPersonen_Refreshing(object sender, EventArgs e)
        {
            listViewPersonen.ItemsSource = await con.Table<Person>().ToListAsync();
            listViewPersonen.EndRefresh();
        }

        private async void ButtonRefreshWPF_Clicked(object sender, EventArgs e)
        {
            listViewPersonen.ItemsSource = await con.Table<Person>().ToListAsync();
        }
    }
}