namespace System.Windows
{
    using Uno.UI.Generic;

    public class StartupEventArgs : Proxy<global::Windows.UI.Xaml.StartupEventArgs>
    {
        public System.String[] Args
        {
            get => __ProxyValue.Args;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}