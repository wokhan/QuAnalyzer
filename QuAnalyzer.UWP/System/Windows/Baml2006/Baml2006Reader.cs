namespace System.Windows.Baml2006
{
    using Uno.UI.Generic;

    public class Baml2006Reader : Proxy<global::Windows.UI.Xaml.Baml2006.Baml2006Reader>
    {
        public System.Xaml.XamlNodeType NodeType
        {
            get => __ProxyValue.NodeType;
        }

        public System.Boolean IsEof
        {
            get => __ProxyValue.IsEof;
        }

        public System.Xaml.NamespaceDeclaration Namespace
        {
            get => __ProxyValue.Namespace;
        }

        public System.Xaml.XamlSchemaContext SchemaContext
        {
            get => __ProxyValue.SchemaContext;
        }

        public System.Xaml.XamlType Type
        {
            get => __ProxyValue.Type;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
        }

        public System.Xaml.XamlMember Member
        {
            get => __ProxyValue.Member;
        }

        public Baml2006Reader(System.String @fileName): base(@fileName)
        {
        }

        public Baml2006Reader(System.IO.Stream @stream): base(@stream)
        {
        }

        public Baml2006Reader(System.IO.Stream @stream, System.Xaml.XamlReaderSettings @xamlReaderSettings): base(@stream, @xamlReaderSettings)
        {
        }

        public System.Boolean Read() => __ProxyValue.Read();
        public void Skip() => __ProxyValue.Skip();
        public void Close() => __ProxyValue.Close();
        public System.Xaml.XamlReader ReadSubtree() => __ProxyValue.ReadSubtree();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}