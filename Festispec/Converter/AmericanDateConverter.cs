using System;
using System.Globalization;
using System.Windows.Data;

namespace Festispec.Converter
{
    public class AmericanDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            DateTime dateTime = (DateTime) value;
            var date = dateTime.ToString("dd MMMM yyyy");
            return date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            DateTime dateTime = (DateTime)value;
            return dateTime.ToString("mm/dd/yyyy");
        }
    }
}
