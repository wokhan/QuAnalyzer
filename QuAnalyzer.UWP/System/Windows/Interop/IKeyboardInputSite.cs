namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class IKeyboardInputSite : Proxy<global::Windows.UI.Xaml.Interop.IKeyboardInputSite>
    {
        public System.Windows.Interop.IKeyboardInputSink Sink
        {
            get => __ProxyValue.Sink;
        }

        public void Unregister() => __ProxyValue.Unregister();
        public System.Boolean OnNoMoreTabStops(System.Windows.Input.TraversalRequest request) => __ProxyValue.OnNoMoreTabStops(@request);
    }
}