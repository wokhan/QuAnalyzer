namespace System.Windows
{
    using Uno.UI.Generic;

    public class FontStyles : Proxy<global::Windows.UI.Xaml.FontStyles>
    {
        public static System.Windows.FontStyle Normal
        {
            get => __ProxyValue.Normal;
        }

        public static System.Windows.FontStyle Oblique
        {
            get => __ProxyValue.Oblique;
        }

        public static System.Windows.FontStyle Italic
        {
            get => __ProxyValue.Italic;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}