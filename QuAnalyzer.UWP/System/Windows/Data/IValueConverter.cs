namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class IValueConverter : Proxy<global::Windows.UI.Xaml.Data.IValueConverter>
    {
        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@value, @targetType, @parameter, @culture);
        public System.Object ConvertBack(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@value, @targetType, @parameter, @culture);
    }
}