namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class CalendarModeChangedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.CalendarModeChangedEventArgs>
    {
        public System.Windows.Controls.CalendarMode NewMode
        {
            get => __ProxyValue.NewMode;
        }

        public System.Windows.Controls.CalendarMode OldMode
        {
            get => __ProxyValue.OldMode;
        }

        public System.Windows.RoutedEvent RoutedEvent
        {
            get => __ProxyValue.RoutedEvent;
            set => __ProxyValue.RoutedEvent = value;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public System.Object Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Object OriginalSource
        {
            get => __ProxyValue.OriginalSource;
        }

        public CalendarModeChangedEventArgs(System.Windows.Controls.CalendarMode @oldMode, System.Windows.Controls.CalendarMode @newMode): base(@oldMode, @newMode)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}