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
	public partial class AppProperties : ContentPage
	{
		public AppProperties ()
		{
			InitializeComponent ();
		}
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            this.BindingContext = this;
        }
        public bool Notifications
        {
            get => (bool)App.Current.Properties["Notifications"];
            set
            {
                App.Current.Properties["Notifications"] = value;
                // Speichern selbst anwerfen:
                // App.Current.SavePropertiesAsync();
            }
        }
    }
}