namespace System.Windows.Media.Effects
{
    using Uno.UI.Generic;

    public class Enumerator : Proxy<global::Windows.UI.Xaml.Media.Effects.Enumerator>
    {
        public System.Windows.Media.Effects.BitmapEffect Current
        {
            get => __ProxyValue.Current;
        }

        public System.Boolean MoveNext() => __ProxyValue.MoveNext();
        public void Reset() => __ProxyValue.Reset();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}