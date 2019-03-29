using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}