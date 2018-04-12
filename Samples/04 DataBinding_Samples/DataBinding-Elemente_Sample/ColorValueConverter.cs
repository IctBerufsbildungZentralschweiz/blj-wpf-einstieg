using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media; // Colors 

namespace DataBinding_Elemente_Sample
{
    public class ColorValueConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = value.ToString();
            string convertedColor = "#FF008000";

            switch (color.ToLower())
            {
                case "rot":
                    convertedColor = Colors.Red.ToString();
                    break;

                case "grün":
                case "gruen":
                    convertedColor = Colors.Green.ToString();
                    break;

                case "blau":
                    convertedColor = Colors.Blue.ToString();
                    break;
            }

            return convertedColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
