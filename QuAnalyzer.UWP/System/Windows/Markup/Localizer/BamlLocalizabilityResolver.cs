namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizabilityResolver : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizabilityResolver>
    {
        public System.Windows.Markup.Localizer.ElementLocalizability GetElementLocalizability(System.String assembly, System.String className) => __ProxyValue.GetElementLocalizability(@assembly, @className);
        public System.Windows.LocalizabilityAttribute GetPropertyLocalizability(System.String assembly, System.String className, System.String property) => __ProxyValue.GetPropertyLocalizability(@assembly, @className, @property);
        public System.String ResolveFormattingTagToClass(System.String formattingTag) => __ProxyValue.ResolveFormattingTagToClass(@formattingTag);
        public System.String ResolveAssemblyFromClass(System.String className) => __ProxyValue.ResolveAssemblyFromClass(@className);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}