namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class ItemsChangedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.Primitives.ItemsChangedEventArgs>
    {
        public System.Collections.Specialized.NotifyCollectionChangedAction Action
        {
            get => __ProxyValue.Action;
        }

        public System.Windows.Controls.Primitives.GeneratorPosition Position
        {
            get => __ProxyValue.Position;
        }

        public System.Windows.Controls.Primitives.GeneratorPosition OldPosition
        {
            get => __ProxyValue.OldPosition;
        }

        public System.Int32 ItemCount
        {
            get => __ProxyValue.ItemCount;
        }

        public System.Int32 ItemUICount
        {
            get => __ProxyValue.ItemUICount;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}