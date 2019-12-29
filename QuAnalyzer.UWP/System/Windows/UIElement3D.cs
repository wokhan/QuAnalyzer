namespace System.Windows
{
    using Uno.UI.Generic;

    public class UIElement3D : Proxy<global::Windows.UI.Xaml.UIElement3D>
    {
        public System.Windows.Input.InputBindingCollection InputBindings
        {
            get => __ProxyValue.InputBindings;
        }

        public System.Windows.Input.CommandBindingCollection CommandBindings
        {
            get => __ProxyValue.CommandBindings;
        }

        public System.Boolean AllowDrop
        {
            get => __ProxyValue.AllowDrop;
            set => __ProxyValue.AllowDrop = value;
        }

        public System.Boolean IsMouseDirectlyOver
        {
            get => __ProxyValue.IsMouseDirectlyOver;
        }

        public System.Boolean IsMouseOver
        {
            get => __ProxyValue.IsMouseOver;
        }

        public System.Boolean IsStylusOver
        {
            get => __ProxyValue.IsStylusOver;
        }

        public System.Boolean IsKeyboardFocusWithin
        {
            get => __ProxyValue.IsKeyboardFocusWithin;
        }

        public System.Boolean IsMouseCaptured
        {
            get => __ProxyValue.IsMouseCaptured;
        }

        public System.Boolean IsMouseCaptureWithin
        {
            get => __ProxyValue.IsMouseCaptureWithin;
        }

        public System.Boolean IsStylusDirectlyOver
        {
            get => __ProxyValue.IsStylusDirectlyOver;
        }

        public System.Boolean IsStylusCaptured
        {
            get => __ProxyValue.IsStylusCaptured;
        }

        public System.Boolean IsStylusCaptureWithin
        {
            get => __ProxyValue.IsStylusCaptureWithin;
        }

        public System.Boolean IsKeyboardFocused
        {
            get => __ProxyValue.IsKeyboardFocused;
        }

        public System.Boolean IsInputMethodEnabled
        {
            get => __ProxyValue.IsInputMethodEnabled;
        }

        public System.Windows.Visibility Visibility
        {
            get => __ProxyValue.Visibility;
            set => __ProxyValue.Visibility = value;
        }

        public System.Boolean IsFocused
        {
            get => __ProxyValue.IsFocused;
        }

        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
            set => __ProxyValue.IsEnabled = value;
        }

        public System.Boolean IsHitTestVisible
        {
            get => __ProxyValue.IsHitTestVisible;
            set => __ProxyValue.IsHitTestVisible = value;
        }

        public System.Boolean IsVisible
        {
            get => __ProxyValue.IsVisible;
        }

        public System.Boolean Focusable
        {
            get => __ProxyValue.Focusable;
            set => __ProxyValue.Focusable = value;
        }

        public System.Boolean AreAnyTouchesOver
        {
            get => __ProxyValue.AreAnyTouchesOver;
        }

        public System.Boolean AreAnyTouchesDirectlyOver
        {
            get => __ProxyValue.AreAnyTouchesDirectlyOver;
        }

        public System.Boolean AreAnyTouchesCapturedWithin
        {
            get => __ProxyValue.AreAnyTouchesCapturedWithin;
        }

        public System.Boolean AreAnyTouchesCaptured
        {
            get => __ProxyValue.AreAnyTouchesCaptured;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesCaptured
        {
            get => __ProxyValue.TouchesCaptured;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesCapturedWithin
        {
            get => __ProxyValue.TouchesCapturedWithin;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesOver
        {
            get => __ProxyValue.TouchesOver;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesDirectlyOver
        {
            get => __ProxyValue.TouchesDirectlyOver;
        }

        public System.Windows.Media.Media3D.Transform3D Transform
        {
            get => __ProxyValue.Transform;
            set => __ProxyValue.Transform = value;
        }

        public System.Boolean HasAnimatedProperties
        {
            get => __ProxyValue.HasAnimatedProperties;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void add_GotFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.add_GotFocus(@value);
        public void remove_GotFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.remove_GotFocus(@value);
        public void add_LostFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.add_LostFocus(@value);
        public void remove_LostFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.remove_LostFocus(@value);
        public void add_IsEnabledChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsEnabledChanged(@value);
        public void remove_IsEnabledChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsEnabledChanged(@value);
        public void add_IsHitTestVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsHitTestVisibleChanged(@value);
        public void remove_IsHitTestVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsHitTestVisibleChanged(@value);
        public void add_IsVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsVisibleChanged(@value);
        public void remove_IsVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsVisibleChanged(@value);
        public void add_FocusableChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_FocusableChanged(@value);
        public void remove_FocusableChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_FocusableChanged(@value);
        public System.Boolean CaptureTouch(System.Windows.Input.TouchDevice touchDevice) => __ProxyValue.CaptureTouch(@touchDevice);
        public System.Boolean ReleaseTouchCapture(System.Windows.Input.TouchDevice touchDevice) => __ProxyValue.ReleaseTouchCapture(@touchDevice);
        public void ReleaseAllTouchCaptures() => __ProxyValue.ReleaseAllTouchCaptures();
        public void add_TouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchMove(@value);
        public void remove_TouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchMove(@value);
        public void add_PreviewTouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_PreviewTouchUp(@value);
        public void remove_PreviewTouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_PreviewTouchUp(@value);
        public void add_TouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchUp(@value);
        public void remove_TouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchUp(@value);
        public void add_GotTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_GotTouchCapture(@value);
        public void remove_GotTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_GotTouchCapture(@value);
        public void add_LostTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_LostTouchCapture(@value);
        public void remove_LostTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_LostTouchCapture(@value);
        public void add_TouchEnter(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchEnter(@value);
        public void remove_TouchEnter(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchEnter(@value);
        public void add_TouchLeave(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchLeave(@value);
        public void remove_TouchLeave(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchLeave(@value);
        public void add_IsMouseDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsMouseDirectlyOverChanged(@value);
        public void remove_IsMouseDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsMouseDirectlyOverChanged(@value);
        public void add_IsKeyboardFocusWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsKeyboardFocusWithinChanged(@value);
        public void remove_IsKeyboardFocusWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsKeyboardFocusWithinChanged(@value);
        public void add_IsMouseCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsMouseCapturedChanged(@value);
        public void remove_IsMouseCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsMouseCapturedChanged(@value);
        public void add_IsMouseCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsMouseCaptureWithinChanged(@value);
        public void remove_IsMouseCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsMouseCaptureWithinChanged(@value);
        public void add_IsStylusDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsStylusDirectlyOverChanged(@value);
        public void remove_IsStylusDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsStylusDirectlyOverChanged(@value);
        public void add_IsStylusCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsStylusCapturedChanged(@value);
        public void remove_IsStylusCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsStylusCapturedChanged(@value);
        public void add_IsStylusCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsStylusCaptureWithinChanged(@value);
        public void remove_IsStylusCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsStylusCaptureWithinChanged(@value);
        public void add_IsKeyboardFocusedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsKeyboardFocusedChanged(@value);
        public void remove_IsKeyboardFocusedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsKeyboardFocusedChanged(@value);
        public void InvalidateModel() => __ProxyValue.InvalidateModel();
        public System.Boolean CaptureMouse() => __ProxyValue.CaptureMouse();
        public void ReleaseMouseCapture() => __ProxyValue.ReleaseMouseCapture();
        public System.Boolean CaptureStylus() => __ProxyValue.CaptureStylus();
        public void ReleaseStylusCapture() => __ProxyValue.ReleaseStylusCapture();
        public System.Boolean Focus() => __ProxyValue.Focus();
        public System.Boolean MoveFocus(System.Windows.Input.TraversalRequest request) => __ProxyValue.MoveFocus(@request);
        public System.Windows.DependencyObject PredictFocus(System.Windows.Input.FocusNavigationDirection direction) => __ProxyValue.PredictFocus(@direction);
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
        public void add_GotStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_GotStylusCapture(@value);
        public void remove_GotStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_GotStylusCapture(@value);
        public void add_LostStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_LostStylusCapture(@value);
        public void remove_LostStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_LostStylusCapture(@value);
        public void add_StylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_StylusButtonDown(@value);
        public void remove_StylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_StylusButtonDown(@value);
        public void add_StylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_StylusButtonUp(@value);
        public void remove_StylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_StylusButtonUp(@value);
        public void add_PreviewStylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_PreviewStylusButtonDown(@value);
        public void remove_PreviewStylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_PreviewStylusButtonDown(@value);
        public void add_PreviewStylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_PreviewStylusButtonUp(@value);
        public void remove_PreviewStylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_PreviewStylusButtonUp(@value);
        public void add_PreviewKeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_PreviewKeyDown(@value);
        public void remove_PreviewKeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_PreviewKeyDown(@value);
        public void add_KeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_KeyDown(@value);
        public void remove_KeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_KeyDown(@value);
        public void add_PreviewKeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_PreviewKeyUp(@value);
        public void remove_PreviewKeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_PreviewKeyUp(@value);
        public void add_KeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_KeyUp(@value);
        public void remove_KeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_KeyUp(@value);
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
        public void add_PreviewQueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.add_PreviewQueryContinueDrag(@value);
        public void remove_PreviewQueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.remove_PreviewQueryContinueDrag(@value);
        public void add_QueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.add_QueryContinueDrag(@value);
        public void remove_QueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.remove_QueryContinueDrag(@value);
        public void add_PreviewGiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.add_PreviewGiveFeedback(@value);
        public void remove_PreviewGiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.remove_PreviewGiveFeedback(@value);
        public void add_GiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.add_GiveFeedback(@value);
        public void remove_GiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.remove_GiveFeedback(@value);
        public void add_PreviewDragEnter(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDragEnter(@value);
        public void remove_PreviewDragEnter(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDragEnter(@value);
        public void add_DragEnter(System.Windows.DragEventHandler value) => __ProxyValue.add_DragEnter(@value);
        public void remove_DragEnter(System.Windows.DragEventHandler value) => __ProxyValue.remove_DragEnter(@value);
        public void add_PreviewDragOver(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDragOver(@value);
        public void remove_PreviewDragOver(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDragOver(@value);
        public void add_DragOver(System.Windows.DragEventHandler value) => __ProxyValue.add_DragOver(@value);
        public void remove_DragOver(System.Windows.DragEventHandler value) => __ProxyValue.remove_DragOver(@value);
        public void add_PreviewDragLeave(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDragLeave(@value);
        public void remove_PreviewDragLeave(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDragLeave(@value);
        public void add_DragLeave(System.Windows.DragEventHandler value) => __ProxyValue.add_DragLeave(@value);
        public void remove_DragLeave(System.Windows.DragEventHandler value) => __ProxyValue.remove_DragLeave(@value);
        public void add_PreviewDrop(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDrop(@value);
        public void remove_PreviewDrop(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDrop(@value);
        public void add_Drop(System.Windows.DragEventHandler value) => __ProxyValue.add_Drop(@value);
        public void remove_Drop(System.Windows.DragEventHandler value) => __ProxyValue.remove_Drop(@value);
        public void add_PreviewTouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_PreviewTouchDown(@value);
        public void remove_PreviewTouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_PreviewTouchDown(@value);
        public void add_TouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchDown(@value);
        public void remove_TouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchDown(@value);
        public void add_PreviewTouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_PreviewTouchMove(@value);
        public void remove_PreviewTouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_PreviewTouchMove(@value);
        public System.Boolean ShouldSerializeInputBindings() => __ProxyValue.ShouldSerializeInputBindings();
        public System.Boolean ShouldSerializeCommandBindings() => __ProxyValue.ShouldSerializeCommandBindings();
        public void RaiseEvent(System.Windows.RoutedEventArgs e) => __ProxyValue.RaiseEvent(@e);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.AddHandler(@routedEvent, @handler);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler, System.Boolean handledEventsToo) => __ProxyValue.AddHandler(@routedEvent, @handler, @handledEventsToo);
        public void RemoveHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.RemoveHandler(@routedEvent, @handler);
        public void AddToEventRoute(System.Windows.EventRoute route, System.Windows.RoutedEventArgs e) => __ProxyValue.AddToEventRoute(@route, @e);
        public void add_PreviewMouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseDown(@value);
        public void remove_PreviewMouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseDown(@value);
        public void add_MouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseDown(@value);
        public void remove_MouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseDown(@value);
        public void add_PreviewMouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseUp(@value);
        public void remove_PreviewMouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseUp(@value);
        public void add_MouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseUp(@value);
        public void remove_MouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseUp(@value);
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
        public void add_QueryCursor(System.Windows.Input.QueryCursorEventHandler value) => __ProxyValue.add_QueryCursor(@value);
        public void remove_QueryCursor(System.Windows.Input.QueryCursorEventHandler value) => __ProxyValue.remove_QueryCursor(@value);
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
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock) => __ProxyValue.ApplyAnimationClock(@dp, @clock);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.ApplyAnimationClock(@dp, @clock, @handoffBehavior);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation) => __ProxyValue.BeginAnimation(@dp, @animation);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.BeginAnimation(@dp, @animation, @handoffBehavior);
        public System.Object GetAnimationBaseValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetAnimationBaseValue(@dp);
        public System.Boolean IsAncestorOf(System.Windows.DependencyObject descendant) => __ProxyValue.IsAncestorOf(@descendant);
        public System.Boolean IsDescendantOf(System.Windows.DependencyObject ancestor) => __ProxyValue.IsDescendantOf(@ancestor);
        public System.Windows.DependencyObject FindCommonVisualAncestor(System.Windows.DependencyObject otherVisual) => __ProxyValue.FindCommonVisualAncestor(@otherVisual);
        public System.Windows.Media.Media3D.GeneralTransform3D TransformToAncestor(System.Windows.Media.Media3D.Visual3D ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public System.Windows.Media.Media3D.GeneralTransform3D TransformToDescendant(System.Windows.Media.Media3D.Visual3D descendant) => __ProxyValue.TransformToDescendant(@descendant);
        public System.Windows.Media.Media3D.GeneralTransform3DTo2D TransformToAncestor(System.Windows.Media.Visual ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}