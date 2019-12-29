namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class IMultiValueConverter : Proxy<global::Windows.UI.Xaml.Data.IMultiValueConverter>
    {
        public System.Object Convert(System.Object[] values, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@values, @targetType, @parameter, @culture);
        public System.Object[] ConvertBack(System.Object value, System.Type[] targetTypes, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@value, @targetTypes, @parameter, @culture);
    }
}