namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextRunProperties : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextRunProperties>
    {
        public System.Windows.Media.Typeface Typeface
        {
            get => __ProxyValue.Typeface;
        }

        public System.Double FontRenderingEmSize
        {
            get => __ProxyValue.FontRenderingEmSize;
        }

        public System.Double FontHintingEmSize
        {
            get => __ProxyValue.FontHintingEmSize;
        }

        public System.Windows.TextDecorationCollection TextDecorations
        {
            get => __ProxyValue.TextDecorations;
        }

        public System.Windows.Media.Brush ForegroundBrush
        {
            get => __ProxyValue.ForegroundBrush;
        }

        public System.Windows.Media.Brush BackgroundBrush
        {
            get => __ProxyValue.BackgroundBrush;
        }

        public System.Globalization.CultureInfo CultureInfo
        {
            get => __ProxyValue.CultureInfo;
        }

        public System.Windows.Media.TextEffectCollection TextEffects
        {
            get => __ProxyValue.TextEffects;
        }

        public System.Windows.BaselineAlignment BaselineAlignment
        {
            get => __ProxyValue.BaselineAlignment;
        }

        public System.Windows.Media.TextFormatting.TextRunTypographyProperties TypographyProperties
        {
            get => __ProxyValue.TypographyProperties;
        }

        public System.Windows.Media.NumberSubstitution NumberSubstitution
        {
            get => __ProxyValue.NumberSubstitution;
        }

        public System.Double PixelsPerDip
        {
            get => __ProxyValue.PixelsPerDip;
            set => __ProxyValue.PixelsPerDip = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}