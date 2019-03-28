using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM_Simpel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonenPage : ContentPage
	{
		public PersonenPage ()
		{
			InitializeComponent ();
            // this.BindingContext = new PersonenViewModel();
		}
	}
}