namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CollectionRegisteringEventArgs : Proxy<global::Windows.UI.Xaml.Data.CollectionRegisteringEventArgs>
    {
        public System.Collections.IEnumerable Collection
        {
            get => __ProxyValue.Collection;
        }

        public System.Object Parent
        {
            get => __ProxyValue.Parent;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}