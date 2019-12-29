namespace System.Windows
{
    using Uno.UI.Generic;

    public class Enumerator<T> : Proxy<global::Windows.UI.Xaml.Enumerator<T>>
    {
        public T Current
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