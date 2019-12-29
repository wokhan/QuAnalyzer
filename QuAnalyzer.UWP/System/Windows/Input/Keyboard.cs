namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class Keyboard : Proxy<global::Windows.UI.Xaml.Input.Keyboard>
    {
        public static System.Windows.IInputElement FocusedElement
        {
            get => __ProxyValue.FocusedElement;
        }

        public static System.Windows.Input.RestoreFocusMode DefaultRestoreFocusMode
        {
            get => __ProxyValue.DefaultRestoreFocusMode;
            set => __ProxyValue.DefaultRestoreFocusMode = value;
        }

        public static System.Windows.Input.ModifierKeys Modifiers
        {
            get => __ProxyValue.Modifiers;
        }

        public static System.Windows.Input.KeyboardDevice PrimaryDevice
        {
            get => __ProxyValue.PrimaryDevice;
        }

        public static void AddPreviewKeyDownHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddPreviewKeyDownHandler(@element, @handler);
        public static void RemovePreviewKeyDownHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemovePreviewKeyDownHandler(@element, @handler);
        public static void AddKeyDownHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddKeyDownHandler(@element, @handler);
        public static void RemoveKeyDownHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemoveKeyDownHandler(@element, @handler);
        public static void AddPreviewKeyUpHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddPreviewKeyUpHandler(@element, @handler);
        public static void RemovePreviewKeyUpHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemovePreviewKeyUpHandler(@element, @handler);
        public static void AddKeyUpHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddKeyUpHandler(@element, @handler);
        public static void RemoveKeyUpHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemoveKeyUpHandler(@element, @handler);
        public static void AddPreviewGotKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddPreviewGotKeyboardFocusHandler(@element, @handler);
        public static void RemovePreviewGotKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemovePreviewGotKeyboardFocusHandler(@element, @handler);
        public static void AddPreviewKeyboardInputProviderAcquireFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardInputProviderAcquireFocusEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddPreviewKeyboardInputProviderAcquireFocusHandler(@element, @handler);
        public static void RemovePreviewKeyboardInputProviderAcquireFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardInputProviderAcquireFocusEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemovePreviewKeyboardInputProviderAcquireFocusHandler(@element, @handler);
        public static void AddKeyboardInputProviderAcquireFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardInputProviderAcquireFocusEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddKeyboardInputProviderAcquireFocusHandler(@element, @handler);
        public static void RemoveKeyboardInputProviderAcquireFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardInputProviderAcquireFocusEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemoveKeyboardInputProviderAcquireFocusHandler(@element, @handler);
        public static void AddGotKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddGotKeyboardFocusHandler(@element, @handler);
        public static void RemoveGotKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemoveGotKeyboardFocusHandler(@element, @handler);
        public static void AddPreviewLostKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddPreviewLostKeyboardFocusHandler(@element, @handler);
        public static void RemovePreviewLostKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemovePreviewLostKeyboardFocusHandler(@element, @handler);
        public static void AddLostKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.AddLostKeyboardFocusHandler(@element, @handler);
        public static void RemoveLostKeyboardFocusHandler(System.Windows.DependencyObject element, System.Windows.Input.KeyboardFocusChangedEventHandler handler) => Windows.UI.Xaml.Input.Keyboard.RemoveLostKeyboardFocusHandler(@element, @handler);
        public static void ClearFocus() => Windows.UI.Xaml.Input.Keyboard.ClearFocus();
        public static System.Windows.IInputElement Focus(System.Windows.IInputElement element) => Windows.UI.Xaml.Input.Keyboard.Focus(@element);
        public static System.Boolean IsKeyDown(System.Windows.Input.Key key) => Windows.UI.Xaml.Input.Keyboard.IsKeyDown(@key);
        public static System.Boolean IsKeyUp(System.Windows.Input.Key key) => Windows.UI.Xaml.Input.Keyboard.IsKeyUp(@key);
        public static System.Boolean IsKeyToggled(System.Windows.Input.Key key) => Windows.UI.Xaml.Input.Keyboard.IsKeyToggled(@key);
        public static System.Windows.Input.KeyStates GetKeyStates(System.Windows.Input.Key key) => Windows.UI.Xaml.Input.Keyboard.GetKeyStates(@key);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}