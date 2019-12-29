namespace System.Windows
{
    using Uno.UI.Generic;

    public class VisualStateChangedEventArgs : Proxy<global::Windows.UI.Xaml.VisualStateChangedEventArgs>
    {
        public System.Windows.VisualState OldState
        {
            get => __ProxyValue.OldState;
        }

        public System.Windows.VisualState NewState
        {
            get => __ProxyValue.NewState;
        }

        public System.Windows.FrameworkElement Control
        {
            get => __ProxyValue.Control;
        }

        public System.Windows.FrameworkElement StateGroupsRoot
        {
            get => __ProxyValue.StateGroupsRoot;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}