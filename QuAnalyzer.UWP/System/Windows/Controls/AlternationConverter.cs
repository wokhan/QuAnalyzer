namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class AlternationConverter : Proxy<global::Windows.UI.Xaml.Controls.AlternationConverter>
    {
        public System.Collections.IList Values
        {
            get => __ProxyValue.Values;
        }

        public AlternationConverter(): base()
        {
        }

        public System.Object Convert(System.Object o, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@o, @targetType, @parameter, @culture);
        public System.Object ConvertBack(System.Object o, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@o, @targetType, @parameter, @culture);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}