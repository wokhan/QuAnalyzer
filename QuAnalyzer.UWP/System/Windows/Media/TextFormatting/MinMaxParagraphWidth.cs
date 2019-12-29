namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class MinMaxParagraphWidth : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.MinMaxParagraphWidth>
    {
        public System.Double MinWidth
        {
            get => __ProxyValue.MinWidth;
        }

        public System.Double MaxWidth
        {
            get => __ProxyValue.MaxWidth;
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Equals(System.Windows.Media.TextFormatting.MinMaxParagraphWidth value) => __ProxyValue.Equals(@value);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public static System.Boolean op_Equality(System.Windows.Media.TextFormatting.MinMaxParagraphWidth left, System.Windows.Media.TextFormatting.MinMaxParagraphWidth right) => Windows.UI.Xaml.Media.TextFormatting.MinMaxParagraphWidth.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Media.TextFormatting.MinMaxParagraphWidth left, System.Windows.Media.TextFormatting.MinMaxParagraphWidth right) => Windows.UI.Xaml.Media.TextFormatting.MinMaxParagraphWidth.op_Inequality(@left, @right);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}