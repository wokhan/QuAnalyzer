namespace System.Windows
{
    using Uno.UI.Generic;

    public class VisualStateManager : Proxy<global::Windows.UI.Xaml.VisualStateManager>
    {
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

        public VisualStateManager(): base()
        {
        }

        public static System.Boolean GoToState(System.Windows.FrameworkElement control, System.String stateName, System.Boolean useTransitions) => Windows.UI.Xaml.VisualStateManager.GoToState(@control, @stateName, @useTransitions);
        public static System.Boolean GoToElementState(System.Windows.FrameworkElement stateGroupsRoot, System.String stateName, System.Boolean useTransitions) => Windows.UI.Xaml.VisualStateManager.GoToElementState(@stateGroupsRoot, @stateName, @useTransitions);
        public static System.Windows.VisualStateManager GetCustomVisualStateManager(System.Windows.FrameworkElement obj) => Windows.UI.Xaml.VisualStateManager.GetCustomVisualStateManager(@obj);
        public static void SetCustomVisualStateManager(System.Windows.FrameworkElement obj, System.Windows.VisualStateManager value) => Windows.UI.Xaml.VisualStateManager.SetCustomVisualStateManager(@obj, @value);
        public static System.Collections.IList GetVisualStateGroups(System.Windows.FrameworkElement obj) => Windows.UI.Xaml.VisualStateManager.GetVisualStateGroups(@obj);
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