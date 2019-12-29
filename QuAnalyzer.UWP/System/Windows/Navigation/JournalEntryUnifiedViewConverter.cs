namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class JournalEntryUnifiedViewConverter : Proxy<global::Windows.UI.Xaml.Navigation.JournalEntryUnifiedViewConverter>
    {
        public JournalEntryUnifiedViewConverter(): base()
        {
        }

        public static System.Windows.Navigation.JournalEntryPosition GetJournalEntryPosition(System.Windows.DependencyObject element) => Windows.UI.Xaml.Navigation.JournalEntryUnifiedViewConverter.GetJournalEntryPosition(@element);
        public static void SetJournalEntryPosition(System.Windows.DependencyObject element, System.Windows.Navigation.JournalEntryPosition position) => Windows.UI.Xaml.Navigation.JournalEntryUnifiedViewConverter.SetJournalEntryPosition(@element, @position);
        public System.Object Convert(System.Object[] values, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.Convert(@values, @targetType, @parameter, @culture);
        public System.Object[] ConvertBack(System.Object value, System.Type[] targetTypes, System.Object parameter, System.Globalization.CultureInfo culture) => __ProxyValue.ConvertBack(@value, @targetTypes, @parameter, @culture);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}