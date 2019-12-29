namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class BooleanToVisibilityConverter : Proxy<global::Windows.UI.Xaml.Controls.BooleanToVisibilityConverter>
    {
        public BooleanToVisibilityConverter(): base()
        {
        }

        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@value, @targetType, @parameter, @culture);
        public System.Object ConvertBack(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@value, @targetType, @parameter, @culture);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}