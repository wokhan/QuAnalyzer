namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class Fonts : Proxy<global::Windows.UI.Xaml.Media.Fonts>
    {
        public static System.Collections.Generic.ICollection<System.Windows.Media.FontFamily> SystemFontFamilies
        {
            get => __ProxyValue.SystemFontFamilies;
        }

        public static System.Collections.Generic.ICollection<System.Windows.Media.Typeface> SystemTypefaces
        {
            get => __ProxyValue.SystemTypefaces;
        }

        public static System.Collections.Generic.ICollection<System.Windows.Media.FontFamily> GetFontFamilies(System.String location) => Windows.UI.Xaml.Media.Fonts.GetFontFamilies(@location);
        public static System.Collections.Generic.ICollection<System.Windows.Media.FontFamily> GetFontFamilies(System.Uri baseUri) => Windows.UI.Xaml.Media.Fonts.GetFontFamilies(@baseUri);
        public static System.Collections.Generic.ICollection<System.Windows.Media.FontFamily> GetFontFamilies(System.Uri baseUri, System.String location) => Windows.UI.Xaml.Media.Fonts.GetFontFamilies(@baseUri, @location);
        public static System.Collections.Generic.ICollection<System.Windows.Media.Typeface> GetTypefaces(System.String location) => Windows.UI.Xaml.Media.Fonts.GetTypefaces(@location);
        public static System.Collections.Generic.ICollection<System.Windows.Media.Typeface> GetTypefaces(System.Uri baseUri) => Windows.UI.Xaml.Media.Fonts.GetTypefaces(@baseUri);
        public static System.Collections.Generic.ICollection<System.Windows.Media.Typeface> GetTypefaces(System.Uri baseUri, System.String location) => Windows.UI.Xaml.Media.Fonts.GetTypefaces(@baseUri, @location);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}