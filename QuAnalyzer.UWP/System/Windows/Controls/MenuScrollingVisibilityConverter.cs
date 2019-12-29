namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class MenuScrollingVisibilityConverter : Proxy<global::Windows.UI.Xaml.Controls.MenuScrollingVisibilityConverter>
    {
        public MenuScrollingVisibilityConverter(): base()
        {
        }

        public System.Object Convert(System.Object[] values, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@values, @targetType, @parameter, @culture);
        public System.Object[] ConvertBack(System.Object value, System.Type[] targetTypes, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@value, @targetTypes, @parameter, @culture);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}