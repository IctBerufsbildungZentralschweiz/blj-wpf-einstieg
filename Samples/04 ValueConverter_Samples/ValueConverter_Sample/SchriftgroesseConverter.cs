using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ValueConverter_Sample
{
    /// <summary>
    /// Konverter-Klasse die einerseits dafür sorgt, dass wir eine genügende grosse Schriftgrösse erhalten 
    /// und andererseits verhindert, dass die Schriftgrösse kleinergleich 0 wird (was zu einem Laufzeitfehler führen würde). <br />
    /// Beispiele: <br />
    ///  - 0 wird konvertiert zu 20 <br />
    ///  - 10 wird konvertiert zu 40 
    /// </summary>
    class SchriftgroesseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double wert = (double)value;
            return 20 + wert * 2; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Implementatin nicht nötig, da wir für die FontSize nur eine OneWay-Bindung von der Quelle zum Ziel 
            throw new NotImplementedException();
        }
    }
}
