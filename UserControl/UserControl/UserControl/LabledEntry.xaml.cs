using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LabledEntry : ContentView
	{
		public LabledEntry ()
		{
			InitializeComponent ();
            BindingContext = this;
		}


        public string Label
        {
            get => label.Text;
            set => label.Text = value;
        }
        public string Placeholder
        {
            get => entry.Placeholder;
            set => entry.Placeholder = value;
        }

        // propdp  -> DependencyProperty aus WPF/UWP erstellen
        // 1) DependencyProperty durch BindableProperty ersetzen
        // 2) BindableProperty.Create anstelle von .Register
        // 3) parameter 1: nameof(Text)
        // 4) parameter 2: Datentyp mit dem aus dem Property abgleichen
        // 5) parameter 3: typeof(LabledEntry) => auf die klasse in der wir drinnen sind anpassen
        // 6) parameter 4: default-value direkt reinschreiben
        // 7) Name des BindablyPropertys anpassen/verändern


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(LabledEntry),string.Empty);




    }
}