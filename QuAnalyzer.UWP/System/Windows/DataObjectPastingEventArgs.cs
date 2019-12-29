namespace System.Windows
{
    using Uno.UI.Generic;

    public class DataObjectPastingEventArgs : Proxy<global::Windows.UI.Xaml.DataObjectPastingEventArgs>
    {
        public System.Windows.IDataObject SourceDataObject
        {
            get => __ProxyValue.SourceDataObject;
        }

        public System.Windows.IDataObject DataObject
        {
            get => __ProxyValue.DataObject;
            set => __ProxyValue.DataObject = value;
        }

        public System.String FormatToApply
        {
            get => __ProxyValue.FormatToApply;
            set => __ProxyValue.FormatToApply = value;
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

        public DataObjectPastingEventArgs(System.Windows.IDataObject @dataObject, System.Boolean @isDragDrop, System.String @formatToApply): base(@dataObject, @isDragDrop, @formatToApply)
        {
        }

        public void CancelCommand() => __ProxyValue.CancelCommand();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}