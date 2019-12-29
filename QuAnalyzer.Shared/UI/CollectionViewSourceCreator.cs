using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace QuAnalyzer.UI.BindingConverters
{
    public sealed partial class CollectionViewSourceCreator : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var source = (value as IEnumerable);
            var cvs = new CollectionViewSource
            {
                Source = source
            };
            cvs.GroupDescriptions.Add(new PropertyGroupDescription((string)parameter));

            return cvs;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Convert(value, targetType, parameter, String.Empty);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ConvertBack(value, targetType, parameter, String.Empty);

    }
}
