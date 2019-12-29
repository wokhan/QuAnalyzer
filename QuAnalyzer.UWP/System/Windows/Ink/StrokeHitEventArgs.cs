namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class StrokeHitEventArgs : Proxy<global::Windows.UI.Xaml.Ink.StrokeHitEventArgs>
    {
        public System.Windows.Ink.Stroke HitStroke
        {
            get => __ProxyValue.HitStroke;
        }

        public System.Windows.Ink.StrokeCollection GetPointEraseResults() => __ProxyValue.GetPointEraseResults();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}