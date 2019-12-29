namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class IContainItemStorage : Proxy<global::Windows.UI.Xaml.Controls.Primitives.IContainItemStorage>
    {
        public void StoreItemValue(System.Object item, System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.StoreItemValue(@item, @dp, @value);
        public System.Object ReadItemValue(System.Object item, System.Windows.DependencyProperty dp) => __ProxyValue.ReadItemValue(@item, @dp);
        public void ClearItemValue(System.Object item, System.Windows.DependencyProperty dp) => __ProxyValue.ClearItemValue(@item, @dp);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void Clear() => __ProxyValue.Clear();
    }
}