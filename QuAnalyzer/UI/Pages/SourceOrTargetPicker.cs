using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QuAnalyzer.UI.Pages;

internal class SourceOrTargetPicker : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var targetValue = values[1 + ((int)values[0] % 2)];
        if (targetValue == DependencyProperty.UnsetValue)
        {
            return "N/A";
        }

        return System.Convert.ChangeType(targetValue, targetType);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
