namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class LinkTarget : Proxy<global::Windows.UI.Xaml.Documents.LinkTarget>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public LinkTarget(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}