namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class JournalEntryListConverter : Proxy<global::Windows.UI.Xaml.Navigation.JournalEntryListConverter>
    {
        public JournalEntryListConverter(): base()
        {
        }

        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@value, @targetType, @parameter, @culture);
        public System.Object ConvertBack(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@value, @targetType, @parameter, @culture);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}