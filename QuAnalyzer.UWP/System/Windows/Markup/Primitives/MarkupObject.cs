namespace System.Windows.Markup.Primitives
{
    using Uno.UI.Generic;

    public class MarkupObject : Proxy<global::Windows.UI.Xaml.Markup.Primitives.MarkupObject>
    {
        public System.Type ObjectType
        {
            get => __ProxyValue.ObjectType;
        }

        public System.Object Instance
        {
            get => __ProxyValue.Instance;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Markup.Primitives.MarkupProperty> Properties
        {
            get => __ProxyValue.Properties;
        }

        public System.ComponentModel.AttributeCollection Attributes
        {
            get => __ProxyValue.Attributes;
        }

        public void AssignRootContext(System.Windows.Markup.IValueSerializerContext context) => __ProxyValue.AssignRootContext(@context);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}