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
	public partial class TextPage : ContentPage
	{
		public TextPage ()
		{
			InitializeComponent ();
		}

        private void ButtonDS_Clicked(object sender, EventArgs e)
        {
           var service =  DependencyService.Get<ITextFileHelper>();

            service.SaveTextFile("demo.txt", entryEingabe.Text);

            DisplayAlert("Message", "Datei wurde erfolgreich gespeichert", "OK");
        }

        private void ButtonDL_Clicked(object sender, EventArgs e)
        {
            var service = DependencyService.Get<ITextFileHelper>();

            DisplayAlert("Textdokument",service.LoadTextFile("demo.txt"),"Yay");
        }

        private void ButtonEssentialsSpeichern_Clicked(object sender, EventArgs e)
        {
            //if(Device.RuntimePlatform == Device.WPF)
            //{

            //}
            string fullPath = Path.Combine(FileSystem.CacheDirectory, "essentialsTest.txt");
            File.WriteAllText(fullPath, entryEingabe.Text);
            DisplayAlert("Essentials", "Datei wurde erfolgreich gespeichert", "OK");
        }

        private void ButtonEssentialsLaden_Clicked(object sender, EventArgs e)
        {
            string fullPath = Path.Combine(FileSystem.CacheDirectory, "essentialsTest.txt");
            DisplayAlert("Essentials", File.ReadAllText(fullPath), "Yay");
        }
    }
}