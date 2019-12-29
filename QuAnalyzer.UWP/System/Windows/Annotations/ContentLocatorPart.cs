namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class ContentLocatorPart : Proxy<global::Windows.UI.Xaml.Annotations.ContentLocatorPart>
    {
        public System.Collections.Generic.IDictionary<System.String, System.String> NameValuePairs
        {
            get => __ProxyValue.NameValuePairs;
        }

        public System.Xml.XmlQualifiedName PartType
        {
            get => __ProxyValue.PartType;
        }

        public ContentLocatorPart(System.Xml.XmlQualifiedName @partType): base(@partType)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}