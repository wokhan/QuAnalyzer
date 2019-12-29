namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class SectionStructure : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.SectionStructure>
    {
        public SectionStructure(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.BlockElement element) => __ProxyValue.Add(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}