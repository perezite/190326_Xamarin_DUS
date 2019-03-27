using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    class EmbeddedImage : IMarkupExtension
    {
        public string ID { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ID == null)
                return null;

            return ImageSource.FromResource(ID);
        }
    }
}
