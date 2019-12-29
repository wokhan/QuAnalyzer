namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CollectionViewRegisteringEventArgs : Proxy<global::Windows.UI.Xaml.Data.CollectionViewRegisteringEventArgs>
    {
        public System.Windows.Data.CollectionView CollectionView
        {
            get => __ProxyValue.CollectionView;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}