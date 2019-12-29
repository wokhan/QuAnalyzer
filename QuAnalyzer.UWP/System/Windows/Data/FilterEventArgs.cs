namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class FilterEventArgs : Proxy<global::Windows.UI.Xaml.Data.FilterEventArgs>
    {
        public System.Object Item
        {
            get => __ProxyValue.Item;
        }

        public System.Boolean Accepted
        {
            get => __ProxyValue.Accepted;
            set => __ProxyValue.Accepted = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}