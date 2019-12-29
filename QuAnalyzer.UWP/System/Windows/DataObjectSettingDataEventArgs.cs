namespace System.Windows
{
    using Uno.UI.Generic;

    public class DataObjectSettingDataEventArgs : Proxy<global::Windows.UI.Xaml.DataObjectSettingDataEventArgs>
    {
        public System.Windows.IDataObject DataObject
        {
            get => __ProxyValue.DataObject;
        }

        public System.String Format
        {
            get => __ProxyValue.Format;
        }

        public System.Boolean IsDragDrop
        {
            get => __ProxyValue.IsDragDrop;
        }

        public System.Boolean CommandCancelled
        {
            get => __ProxyValue.CommandCancelled;
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

        public DataObjectSettingDataEventArgs(System.Windows.IDataObject @dataObject, System.String @format): base(@dataObject, @format)
        {
        }

        public void CancelCommand() => __ProxyValue.CancelCommand();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}