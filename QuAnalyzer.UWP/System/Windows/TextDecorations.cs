namespace System.Windows
{
    using Uno.UI.Generic;

    public class TextDecorations : Proxy<global::Windows.UI.Xaml.TextDecorations>
    {
        public static System.Windows.TextDecorationCollection Underline
        {
            get => __ProxyValue.Underline;
        }

        public static System.Windows.TextDecorationCollection Strikethrough
        {
            get => __ProxyValue.Strikethrough;
        }

        public static System.Windows.TextDecorationCollection OverLine
        {
            get => __ProxyValue.OverLine;
        }

        public static System.Windows.TextDecorationCollection Baseline
        {
            get => __ProxyValue.Baseline;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}