namespace System.Windows
{
    using Uno.UI.Generic;

    public class AutoResizedEventArgs : Proxy<global::Windows.UI.Xaml.AutoResizedEventArgs>
    {
        public System.Windows.Size Size
        {
            get => __ProxyValue.Size;
        }

        public AutoResizedEventArgs(System.Windows.Size @size): base(@size)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}