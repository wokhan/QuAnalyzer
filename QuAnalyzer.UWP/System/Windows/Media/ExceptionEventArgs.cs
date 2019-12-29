namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class ExceptionEventArgs : Proxy<global::Windows.UI.Xaml.Media.ExceptionEventArgs>
    {
        public System.Exception ErrorException
        {
            get => __ProxyValue.ErrorException;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}