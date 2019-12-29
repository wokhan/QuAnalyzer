namespace System.Windows.Markup.Primitives
{
    using Uno.UI.Generic;

    public class MarkupProperty : Proxy<global::Windows.UI.Xaml.Markup.Primitives.MarkupProperty>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Type PropertyType
        {
            get => __ProxyValue.PropertyType;
        }

        public System.ComponentModel.PropertyDescriptor PropertyDescriptor
        {
            get => __ProxyValue.PropertyDescriptor;
        }

        public System.Windows.DependencyProperty DependencyProperty
        {
            get => __ProxyValue.DependencyProperty;
        }

        public System.Boolean IsAttached
        {
            get => __ProxyValue.IsAttached;
        }

        public System.Boolean IsConstructorArgument
        {
            get => __ProxyValue.IsConstructorArgument;
        }

        public System.Boolean IsValueAsString
        {
            get => __ProxyValue.IsValueAsString;
        }

        public System.Boolean IsContent
        {
            get => __ProxyValue.IsContent;
        }

        public System.Boolean IsKey
        {
            get => __ProxyValue.IsKey;
        }

        public System.Boolean IsComposite
        {
            get => __ProxyValue.IsComposite;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
        }

        public System.String StringValue
        {
            get => __ProxyValue.StringValue;
        }

        public System.Collections.Generic.IEnumerable<System.Type> TypeReferences
        {
            get => __ProxyValue.TypeReferences;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Markup.Primitives.MarkupObject> Items
        {
            get => __ProxyValue.Items;
        }

        public System.ComponentModel.AttributeCollection Attributes
        {
            get => __ProxyValue.Attributes;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}