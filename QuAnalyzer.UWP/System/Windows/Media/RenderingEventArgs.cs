namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class RenderingEventArgs : Proxy<global::Windows.UI.Xaml.Media.RenderingEventArgs>
    {
        public System.TimeSpan RenderingTime
        {
            get => __ProxyValue.RenderingTime;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}