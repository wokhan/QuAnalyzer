namespace System.Windows
{
    using Uno.UI.Generic;

    public class ThemeInfoAttribute : Proxy<global::Windows.UI.Xaml.ThemeInfoAttribute>
    {
        public System.Windows.ResourceDictionaryLocation ThemeDictionaryLocation
        {
            get => __ProxyValue.ThemeDictionaryLocation;
        }

        public System.Windows.ResourceDictionaryLocation GenericDictionaryLocation
        {
            get => __ProxyValue.GenericDictionaryLocation;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public ThemeInfoAttribute(System.Windows.ResourceDictionaryLocation @themeDictionaryLocation, System.Windows.ResourceDictionaryLocation @genericDictionaryLocation): base(@themeDictionaryLocation, @genericDictionaryLocation)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}