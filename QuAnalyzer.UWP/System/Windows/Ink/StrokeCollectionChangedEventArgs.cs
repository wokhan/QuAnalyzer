namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class StrokeCollectionChangedEventArgs : Proxy<global::Windows.UI.Xaml.Ink.StrokeCollectionChangedEventArgs>
    {
        public System.Windows.Ink.StrokeCollection Added
        {
            get => __ProxyValue.Added;
        }

        public System.Windows.Ink.StrokeCollection Removed
        {
            get => __ProxyValue.Removed;
        }

        public StrokeCollectionChangedEventArgs(System.Windows.Ink.StrokeCollection @added, System.Windows.Ink.StrokeCollection @removed): base(@added, @removed)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}