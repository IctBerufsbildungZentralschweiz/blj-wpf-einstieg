using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace _04_UpperCaseConverter
{
    class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                bool visible = (bool)value;

                if (parameter != null && parameter.ToString() == "invisible")
                    visible = !(bool)value;
                
                if (visible)
                    return  Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // die Rückumwandlung wird nicht benötigt
            throw new NotImplementedException();
        }
    }
}
