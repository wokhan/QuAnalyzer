namespace System.Windows
{
    using Uno.UI.Generic;

    public class ThemeDictionaryExtension : Proxy<global::Windows.UI.Xaml.ThemeDictionaryExtension>
    {
        public System.String AssemblyName
        {
            get => __ProxyValue.AssemblyName;
            set => __ProxyValue.AssemblyName = value;
        }

        public ThemeDictionaryExtension(): base()
        {
        }

        public ThemeDictionaryExtension(System.String @assemblyName): base(@assemblyName)
        {
        }

        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}