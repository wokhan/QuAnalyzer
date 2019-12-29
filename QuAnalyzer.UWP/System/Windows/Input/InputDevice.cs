namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputDevice : Proxy<global::Windows.UI.Xaml.Input.InputDevice>
    {
        public System.Windows.IInputElement Target
        {
            get => __ProxyValue.Target;
        }

        public System.Windows.PresentationSource ActiveSource
        {
            get => __ProxyValue.ActiveSource;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}