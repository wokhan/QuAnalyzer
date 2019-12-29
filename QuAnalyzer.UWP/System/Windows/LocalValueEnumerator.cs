namespace System.Windows
{
    using Uno.UI.Generic;

    public class LocalValueEnumerator : Proxy<global::Windows.UI.Xaml.LocalValueEnumerator>
    {
        public System.Windows.LocalValueEntry Current
        {
            get => __ProxyValue.Current;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public static System.Boolean op_Equality(System.Windows.LocalValueEnumerator obj1, System.Windows.LocalValueEnumerator obj2) => Windows.UI.Xaml.LocalValueEnumerator.op_Equality(@obj1, @obj2);
        public static System.Boolean op_Inequality(System.Windows.LocalValueEnumerator obj1, System.Windows.LocalValueEnumerator obj2) => Windows.UI.Xaml.LocalValueEnumerator.op_Inequality(@obj1, @obj2);
        public System.Boolean MoveNext() => __ProxyValue.MoveNext();
        public void Reset() => __ProxyValue.Reset();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}