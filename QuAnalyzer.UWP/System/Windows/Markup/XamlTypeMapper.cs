namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XamlTypeMapper : Proxy<global::Windows.UI.Xaml.Markup.XamlTypeMapper>
    {
        public static System.Windows.Markup.XamlTypeMapper DefaultMapper
        {
            get => __ProxyValue.DefaultMapper;
        }

        public XamlTypeMapper(System.String[] @assemblyNames): base(@assemblyNames)
        {
        }

        public XamlTypeMapper(System.String[] @assemblyNames, System.Windows.Markup.NamespaceMapEntry[] @namespaceMaps): base(@assemblyNames, @namespaceMaps)
        {
        }

        public void AddMappingProcessingInstruction(System.String xmlNamespace, System.String clrNamespace, System.String assemblyName) => __ProxyValue.AddMappingProcessingInstruction(@xmlNamespace, @clrNamespace, @assemblyName);
        public void SetAssemblyPath(System.String assemblyName, System.String assemblyPath) => __ProxyValue.SetAssemblyPath(@assemblyName, @assemblyPath);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}