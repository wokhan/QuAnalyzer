namespace System.Windows
{
    using Uno.UI.Generic;

    public class EventPrivateKey : Proxy<global::Windows.UI.Xaml.EventPrivateKey>
    {
        public EventPrivateKey(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}