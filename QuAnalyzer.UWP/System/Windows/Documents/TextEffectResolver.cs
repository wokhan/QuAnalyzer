namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class TextEffectResolver : Proxy<global::Windows.UI.Xaml.Documents.TextEffectResolver>
    {
        public static System.Windows.Documents.TextEffectTarget[] Resolve(System.Windows.Documents.TextPointer startPosition, System.Windows.Documents.TextPointer endPosition, System.Windows.Media.TextEffect effect) => Windows.UI.Xaml.Documents.TextEffectResolver.Resolve(@startPosition, @endPosition, @effect);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}