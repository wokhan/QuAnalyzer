namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class IKeyboardInputSink : Proxy<global::Windows.UI.Xaml.Interop.IKeyboardInputSink>
    {
        public System.Windows.Interop.IKeyboardInputSite KeyboardInputSite
        {
            get => __ProxyValue.KeyboardInputSite;
            set => __ProxyValue.KeyboardInputSite = value;
        }

        public System.Windows.Interop.IKeyboardInputSite RegisterKeyboardInputSink(System.Windows.Interop.IKeyboardInputSink sink) => __ProxyValue.RegisterKeyboardInputSink(@sink);
        public System.Boolean TranslateAccelerator(System.Windows.Interop.MSG msg, System.Windows.Input.ModifierKeys modifiers) => __ProxyValue.TranslateAccelerator(@msg, @modifiers);
        public System.Boolean TabInto(System.Windows.Input.TraversalRequest request) => __ProxyValue.TabInto(@request);
        public System.Boolean OnMnemonic(System.Windows.Interop.MSG msg, System.Windows.Input.ModifierKeys modifiers) => __ProxyValue.OnMnemonic(@msg, @modifiers);
        public System.Boolean TranslateChar(System.Windows.Interop.MSG msg, System.Windows.Input.ModifierKeys modifiers) => __ProxyValue.TranslateChar(@msg, @modifiers);
        public System.Boolean HasFocusWithin() => __ProxyValue.HasFocusWithin();
    }
}