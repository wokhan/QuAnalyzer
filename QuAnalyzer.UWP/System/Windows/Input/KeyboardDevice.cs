namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class KeyboardDevice : Proxy<global::Windows.UI.Xaml.Input.KeyboardDevice>
    {
        public System.Windows.IInputElement Target
        {
            get => __ProxyValue.Target;
        }

        public System.Windows.PresentationSource ActiveSource
        {
            get => __ProxyValue.ActiveSource;
        }

        public System.Windows.Input.RestoreFocusMode DefaultRestoreFocusMode
        {
            get => __ProxyValue.DefaultRestoreFocusMode;
            set => __ProxyValue.DefaultRestoreFocusMode = value;
        }

        public System.Windows.IInputElement FocusedElement
        {
            get => __ProxyValue.FocusedElement;
        }

        public System.Windows.Input.ModifierKeys Modifiers
        {
            get => __ProxyValue.Modifiers;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void ClearFocus() => __ProxyValue.ClearFocus();
        public System.Windows.IInputElement Focus(System.Windows.IInputElement element) => __ProxyValue.Focus(@element);
        public System.Boolean IsKeyDown(System.Windows.Input.Key key) => __ProxyValue.IsKeyDown(@key);
        public System.Boolean IsKeyUp(System.Windows.Input.Key key) => __ProxyValue.IsKeyUp(@key);
        public System.Boolean IsKeyToggled(System.Windows.Input.Key key) => __ProxyValue.IsKeyToggled(@key);
        public System.Windows.Input.KeyStates GetKeyStates(System.Windows.Input.Key key) => __ProxyValue.GetKeyStates(@key);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}