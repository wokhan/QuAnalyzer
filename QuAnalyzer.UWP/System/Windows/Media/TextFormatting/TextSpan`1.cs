namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextSpan`1<T> : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextSpan<T>>
    {
        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public T Value
        {
            get => __ProxyValue.Value;
        }

        public TextSpan`1(System.Int32 @length, T @value): base(@length, @value)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}