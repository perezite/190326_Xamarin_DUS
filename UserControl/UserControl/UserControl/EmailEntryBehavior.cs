using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace UserControl
{
    public class EmailEntryBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regex.IsMatch(e.NewTextValue, @"[a-zA-Z0-9\.]+@[a-zA-Z0-9.]+\.[a-zA-Z]{2,5}"))
            {
                (sender as Entry).TextColor = Color.Black;
            }
            else
            {
                (sender as Entry).TextColor = Color.Red;
            }
        }
    }
}
