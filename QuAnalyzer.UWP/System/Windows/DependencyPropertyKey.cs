namespace System.Windows
{
    using Uno.UI.Generic;

    public class DependencyPropertyKey : Proxy<global::Windows.UI.Xaml.DependencyPropertyKey>
    {
        public System.Windows.DependencyProperty DependencyProperty
        {
            get => __ProxyValue.DependencyProperty;
        }

        public void OverrideMetadata(System.Type forType, System.Windows.PropertyMetadata typeMetadata) => __ProxyValue.OverrideMetadata(@forType, @typeMetadata);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}