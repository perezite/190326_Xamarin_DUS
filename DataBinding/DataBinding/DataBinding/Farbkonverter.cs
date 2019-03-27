using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DataBinding
{
    class Farbkonverter : IValueConverter
    {
        // OneWay
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = value as string;
            if (color == null)
                return Color.White;

            var resultColor = typeof(Color).GetFields().FirstOrDefault(x => x.Name.ToLower() == color.ToLower());
            if (resultColor == null)
                return Color.White;
            else
                return resultColor.GetValue(typeof(Color));
        }

        // Wichtig beim TwoWayBinding
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
