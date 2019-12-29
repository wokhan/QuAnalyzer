namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class ResourceDictionaryInfo : Proxy<global::Windows.UI.Xaml.Diagnostics.ResourceDictionaryInfo>
    {
        public System.Reflection.Assembly Assembly
        {
            get => __ProxyValue.Assembly;
        }

        public System.Reflection.Assembly ResourceDictionaryAssembly
        {
            get => __ProxyValue.ResourceDictionaryAssembly;
        }

        public System.Windows.ResourceDictionary ResourceDictionary
        {
            get => __ProxyValue.ResourceDictionary;
        }

        public System.Uri SourceUri
        {
            get => __ProxyValue.SourceUri;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}