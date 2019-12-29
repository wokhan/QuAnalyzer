namespace System.Windows
{
    using Uno.UI.Generic;

    public class IInputElement : Proxy<global::Windows.UI.Xaml.IInputElement>
    {
        public System.Boolean IsMouseOver
        {
            get => __ProxyValue.IsMouseOver;
        }

        public System.Boolean IsMouseDirectlyOver
        {
            get => __ProxyValue.IsMouseDirectlyOver;
        }

        public System.Boolean IsMouseCaptured
        {
            get => __ProxyValue.IsMouseCaptured;
        }

        public System.Boolean IsStylusOver
        {
            get => __ProxyValue.IsStylusOver;
        }

        public System.Boolean IsStylusDirectlyOver
        {
            get => __ProxyValue.IsStylusDirectlyOver;
        }

        public System.Boolean IsStylusCaptured
        {
            get => __ProxyValue.IsStylusCaptured;
        }

        public System.Boolean IsKeyboardFocusWithin
        {
            get => __ProxyValue.IsKeyboardFocusWithin;
        }

        public System.Boolean IsKeyboardFocused
        {
            get => __ProxyValue.IsKeyboardFocused;
        }

        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
        }

        public System.Boolean Focusable
        {
            get => __ProxyValue.Focusable;
            set => __ProxyValue.Focusable = value;
        }

        public void RaiseEvent(System.Windows.RoutedEventArgs e) => __ProxyValue.RaiseEvent(@e);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.AddHandler(@routedEvent, @handler);
        public void RemoveHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.RemoveHandler(@routedEvent, @handler);
        public void add_PreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseLeftButtonDown(@value);
        public void remove_PreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseLeftButtonDown(@value);
        public void add_MouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseLeftButtonDown(@value);
        public void remove_MouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseLeftButtonDown(@value);
        public void add_PreviewMouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseLeftButtonUp(@value);
        public void remove_PreviewMouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseLeftButtonUp(@value);
        public void add_MouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseLeftButtonUp(@value);
        public void remove_MouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseLeftButtonUp(@value);
        public void add_PreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseRightButtonDown(@value);
        public void remove_PreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseRightButtonDown(@value);
        public void add_MouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseRightButtonDown(@value);
        public void remove_MouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseRightButtonDown(@value);
        public void add_PreviewMouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseRightButtonUp(@value);
        public void remove_PreviewMouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseRightButtonUp(@value);
        public void add_MouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseRightButtonUp(@value);
        public void remove_MouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseRightButtonUp(@value);
        public void add_PreviewMouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_PreviewMouseMove(@value);
        public void remove_PreviewMouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_PreviewMouseMove(@value);
        public void add_MouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_MouseMove(@value);
        public void remove_MouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_MouseMove(@value);
        public void add_PreviewMouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.add_PreviewMouseWheel(@value);
        public void remove_PreviewMouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.remove_PreviewMouseWheel(@value);
        public void add_MouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.add_MouseWheel(@value);
        public void remove_MouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.remove_MouseWheel(@value);
        public void add_MouseEnter(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_MouseEnter(@value);
        public void remove_MouseEnter(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_MouseEnter(@value);
        public void add_MouseLeave(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_MouseLeave(@value);
        public void remove_MouseLeave(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_MouseLeave(@value);
        public void add_GotMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_GotMouseCapture(@value);
        public void remove_GotMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_GotMouseCapture(@value);
        public void add_LostMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_LostMouseCapture(@value);
        public void remove_LostMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_LostMouseCapture(@value);
        public System.Boolean CaptureMouse() => __ProxyValue.CaptureMouse();
        public void ReleaseMouseCapture() => __ProxyValue.ReleaseMouseCapture();
        public void add_PreviewStylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.add_PreviewStylusDown(@value);
        public void remove_PreviewStylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.remove_PreviewStylusDown(@value);
        public void add_StylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.add_StylusDown(@value);
        public void remove_StylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.remove_StylusDown(@value);
        public void add_PreviewStylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusUp(@value);
        public void remove_PreviewStylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusUp(@value);
        public void add_StylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusUp(@value);
        public void remove_StylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusUp(@value);
        public void add_PreviewStylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusMove(@value);
        public void remove_PreviewStylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusMove(@value);
        public void add_StylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusMove(@value);
        public void remove_StylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusMove(@value);
        public void add_PreviewStylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusInAirMove(@value);
        public void remove_PreviewStylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusInAirMove(@value);
        public void add_StylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusInAirMove(@value);
        public void remove_StylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusInAirMove(@value);
        public void add_StylusEnter(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusEnter(@value);
        public void remove_StylusEnter(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusEnter(@value);
        public void add_StylusLeave(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusLeave(@value);
        public void remove_StylusLeave(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusLeave(@value);
        public void add_PreviewStylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusInRange(@value);
        public void remove_PreviewStylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusInRange(@value);
        public void add_StylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusInRange(@value);
        public void remove_StylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusInRange(@value);
        public void add_PreviewStylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusOutOfRange(@value);
        public void remove_PreviewStylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusOutOfRange(@value);
        public void add_StylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusOutOfRange(@value);
        public void remove_StylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusOutOfRange(@value);
        public void add_PreviewStylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.add_PreviewStylusSystemGesture(@value);
        public void remove_PreviewStylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.remove_PreviewStylusSystemGesture(@value);
        public void add_StylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.add_StylusSystemGesture(@value);
        public void remove_StylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.remove_StylusSystemGesture(@value);
        public void add_StylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_StylusButtonDown(@value);
        public void remove_StylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_StylusButtonDown(@value);
        public void add_PreviewStylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_PreviewStylusButtonDown(@value);
        public void remove_PreviewStylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_PreviewStylusButtonDown(@value);
        public void add_PreviewStylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_PreviewStylusButtonUp(@value);
        public void remove_PreviewStylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_PreviewStylusButtonUp(@value);
        public void add_StylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_StylusButtonUp(@value);
        public void remove_StylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_StylusButtonUp(@value);
        public void add_GotStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_GotStylusCapture(@value);
        public void remove_GotStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_GotStylusCapture(@value);
        public void add_LostStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_LostStylusCapture(@value);
        public void remove_LostStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_LostStylusCapture(@value);
        public System.Boolean CaptureStylus() => __ProxyValue.CaptureStylus();
        public void ReleaseStylusCapture() => __ProxyValue.ReleaseStylusCapture();
        public void add_PreviewKeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_PreviewKeyDown(@value);
        public void remove_PreviewKeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_PreviewKeyDown(@value);
        public void add_KeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_KeyDown(@value);
        public void remove_KeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_KeyDown(@value);
        public void add_PreviewKeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_PreviewKeyUp(@value);
        public void remove_PreviewKeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_PreviewKeyUp(@value);
        public void add_KeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_KeyUp(@value);
        public void remove_KeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_KeyUp(@value);
        public System.Boolean Focus() => __ProxyValue.Focus();
        public void add_PreviewGotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_PreviewGotKeyboardFocus(@value);
        public void remove_PreviewGotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_PreviewGotKeyboardFocus(@value);
        public void add_GotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_GotKeyboardFocus(@value);
        public void remove_GotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_GotKeyboardFocus(@value);
        public void add_PreviewLostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_PreviewLostKeyboardFocus(@value);
        public void remove_PreviewLostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_PreviewLostKeyboardFocus(@value);
        public void add_LostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_LostKeyboardFocus(@value);
        public void remove_LostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_LostKeyboardFocus(@value);
        public void add_PreviewTextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.add_PreviewTextInput(@value);
        public void remove_PreviewTextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.remove_PreviewTextInput(@value);
        public void add_TextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.add_TextInput(@value);
        public void remove_TextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.remove_TextInput(@value);
    }
}