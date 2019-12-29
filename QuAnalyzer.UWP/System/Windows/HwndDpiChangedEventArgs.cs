namespace System.Windows
{
    using Uno.UI.Generic;

    public class HwndDpiChangedEventArgs : Proxy<global::Windows.UI.Xaml.HwndDpiChangedEventArgs>
    {
        public System.Windows.DpiScale OldDpi
        {
            get => __ProxyValue.OldDpi;
        }

        public System.Windows.DpiScale NewDpi
        {
            get => __ProxyValue.NewDpi;
        }

        public System.Windows.Rect SuggestedRect
        {
            get => __ProxyValue.SuggestedRect;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}