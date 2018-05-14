using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _04_UpperCaseConverter
{
    class UpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (parameter != null && parameter.ToString() == "toupper")
                    return value.ToString().ToUpper();
                else
                    return value.ToString().ToLower();
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // die Rückumwandlung wäre relativ schwierig zu bewerkstelligen, lassen wir sie darum weg, da sie eh nicht benötigt wird
            throw new NotImplementedException();
        }
    }
}
