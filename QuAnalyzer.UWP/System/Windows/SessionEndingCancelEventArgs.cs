namespace System.Windows
{
    using Uno.UI.Generic;

    public class SessionEndingCancelEventArgs : Proxy<global::Windows.UI.Xaml.SessionEndingCancelEventArgs>
    {
        public System.Windows.ReasonSessionEnding ReasonSessionEnding
        {
            get => __ProxyValue.ReasonSessionEnding;
        }

        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}