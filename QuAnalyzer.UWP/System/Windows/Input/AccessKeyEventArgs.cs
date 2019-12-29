namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class AccessKeyEventArgs : Proxy<global::Windows.UI.Xaml.Input.AccessKeyEventArgs>
    {
        public System.String Key
        {
            get => __ProxyValue.Key;
        }

        public System.Boolean IsMultiple
        {
            get => __ProxyValue.IsMultiple;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}