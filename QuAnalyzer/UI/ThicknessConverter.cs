using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace QuAnalyzer.UI.BindingConverters
{
    public sealed partial class ThicknessConverter : DependencyObject, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var margin = (value as double?) ?? 0;
            switch (parameter)
            {
                case "LEFT":
                    return new Thickness(margin, 0, 0, 0);
                case "RIGHT":
                    return new Thickness(0, 0, margin, 0);
                case "LEFTRIGHT":
                    return new Thickness(margin, 0, margin, 0);
                case "TOP":
                    return new Thickness(0, margin, 0, margin);
                case "BOTTOM":
                    return new Thickness(0, margin, 0, margin);
                case "TOPBOTTOM":
                    return new Thickness(0, margin, 0, margin);
                default:
                    return new Thickness();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Convert(value, targetType, parameter, String.Empty);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ConvertBack(value, targetType, parameter, String.Empty);

    }
}
