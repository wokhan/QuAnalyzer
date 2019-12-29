namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputGesture : Proxy<global::Windows.UI.Xaml.Input.InputGesture>
    {
        public System.Boolean Matches(System.Object targetElement, System.Windows.Input.InputEventArgs inputEventArgs) => __ProxyValue.Matches(@targetElement, @inputEventArgs);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}