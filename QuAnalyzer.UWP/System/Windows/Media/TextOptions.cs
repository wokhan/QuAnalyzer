namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class TextOptions : Proxy<global::Windows.UI.Xaml.Media.TextOptions>
    {
        public static void SetTextFormattingMode(System.Windows.DependencyObject element, System.Windows.Media.TextFormattingMode value) => Windows.UI.Xaml.Media.TextOptions.SetTextFormattingMode(@element, @value);
        public static System.Windows.Media.TextFormattingMode GetTextFormattingMode(System.Windows.DependencyObject element) => Windows.UI.Xaml.Media.TextOptions.GetTextFormattingMode(@element);
        public static void SetTextRenderingMode(System.Windows.DependencyObject element, System.Windows.Media.TextRenderingMode value) => Windows.UI.Xaml.Media.TextOptions.SetTextRenderingMode(@element, @value);
        public static System.Windows.Media.TextRenderingMode GetTextRenderingMode(System.Windows.DependencyObject element) => Windows.UI.Xaml.Media.TextOptions.GetTextRenderingMode(@element);
        public static void SetTextHintingMode(System.Windows.DependencyObject element, System.Windows.Media.TextHintingMode value) => Windows.UI.Xaml.Media.TextOptions.SetTextHintingMode(@element, @value);
        public static System.Windows.Media.TextHintingMode GetTextHintingMode(System.Windows.DependencyObject element) => Windows.UI.Xaml.Media.TextOptions.GetTextHintingMode(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}