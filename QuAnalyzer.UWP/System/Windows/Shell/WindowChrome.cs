namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class WindowChrome : Proxy<global::Windows.UI.Xaml.Shell.WindowChrome>
    {
        public static System.Windows.Thickness GlassFrameCompleteThickness
        {
            get => __ProxyValue.GlassFrameCompleteThickness;
        }

        public System.Double CaptionHeight
        {
            get => __ProxyValue.CaptionHeight;
            set => __ProxyValue.CaptionHeight = value;
        }

        public System.Windows.Thickness ResizeBorderThickness
        {
            get => __ProxyValue.ResizeBorderThickness;
            set => __ProxyValue.ResizeBorderThickness = value;
        }

        public System.Windows.Thickness GlassFrameThickness
        {
            get => __ProxyValue.GlassFrameThickness;
            set => __ProxyValue.GlassFrameThickness = value;
        }

        public System.Boolean UseAeroCaptionButtons
        {
            get => __ProxyValue.UseAeroCaptionButtons;
            set => __ProxyValue.UseAeroCaptionButtons = value;
        }

        public System.Windows.CornerRadius CornerRadius
        {
            get => __ProxyValue.CornerRadius;
            set => __ProxyValue.CornerRadius = value;
        }

        public System.Windows.Shell.NonClientFrameEdges NonClientFrameEdges
        {
            get => __ProxyValue.NonClientFrameEdges;
            set => __ProxyValue.NonClientFrameEdges = value;
        }

        public System.Boolean CanFreeze
        {
            get => __ProxyValue.CanFreeze;
        }

        public System.Boolean IsFrozen
        {
            get => __ProxyValue.IsFrozen;
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

        public WindowChrome(): base()
        {
        }

        public static System.Windows.Shell.WindowChrome GetWindowChrome(System.Windows.Window window) => Windows.UI.Xaml.Shell.WindowChrome.GetWindowChrome(@window);
        public static void SetWindowChrome(System.Windows.Window window, System.Windows.Shell.WindowChrome chrome) => Windows.UI.Xaml.Shell.WindowChrome.SetWindowChrome(@window, @chrome);
        public static System.Boolean GetIsHitTestVisibleInChrome(System.Windows.IInputElement inputElement) => Windows.UI.Xaml.Shell.WindowChrome.GetIsHitTestVisibleInChrome(@inputElement);
        public static void SetIsHitTestVisibleInChrome(System.Windows.IInputElement inputElement, System.Boolean hitTestVisible) => Windows.UI.Xaml.Shell.WindowChrome.SetIsHitTestVisibleInChrome(@inputElement, @hitTestVisible);
        public static System.Windows.Shell.ResizeGripDirection GetResizeGripDirection(System.Windows.IInputElement inputElement) => Windows.UI.Xaml.Shell.WindowChrome.GetResizeGripDirection(@inputElement);
        public static void SetResizeGripDirection(System.Windows.IInputElement inputElement, System.Windows.Shell.ResizeGripDirection direction) => Windows.UI.Xaml.Shell.WindowChrome.SetResizeGripDirection(@inputElement, @direction);
        public System.Windows.Freezable Clone() => __ProxyValue.Clone();
        public System.Windows.Freezable CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Windows.Freezable GetAsFrozen() => __ProxyValue.GetAsFrozen();
        public System.Windows.Freezable GetCurrentValueAsFrozen() => __ProxyValue.GetCurrentValueAsFrozen();
        public void Freeze() => __ProxyValue.Freeze();
        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
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