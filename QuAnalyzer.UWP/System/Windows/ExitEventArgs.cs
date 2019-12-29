namespace System.Windows
{
    using Uno.UI.Generic;

    public class ExitEventArgs : Proxy<global::Windows.UI.Xaml.ExitEventArgs>
    {
        public System.Int32 ApplicationExitCode
        {
            get => __ProxyValue.ApplicationExitCode;
            set => __ProxyValue.ApplicationExitCode = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}