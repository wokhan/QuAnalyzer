using System;
using System.Globalization;
using System.Windows.Data;

namespace QuAnalyzer.Helpers.BindingConverters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class ObjectToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null && !String.IsNullOrEmpty(value.ToString().Trim()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
