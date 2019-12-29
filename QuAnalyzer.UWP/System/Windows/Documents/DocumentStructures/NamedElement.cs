namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class NamedElement : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.NamedElement>
    {
        public System.String NameReference
        {
            get => __ProxyValue.NameReference;
            set => __ProxyValue.NameReference = value;
        }

        public NamedElement(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}