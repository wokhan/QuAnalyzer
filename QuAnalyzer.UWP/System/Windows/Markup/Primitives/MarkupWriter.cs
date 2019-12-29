namespace System.Windows.Markup.Primitives
{
    using Uno.UI.Generic;

    public class MarkupWriter : Proxy<global::Windows.UI.Xaml.Markup.Primitives.MarkupWriter>
    {
        public static System.Windows.Markup.Primitives.MarkupObject GetMarkupObjectFor(System.Object instance) => Windows.UI.Xaml.Markup.Primitives.MarkupWriter.GetMarkupObjectFor(@instance);
        public static System.Windows.Markup.Primitives.MarkupObject GetMarkupObjectFor(System.Object instance, System.Windows.Markup.XamlDesignerSerializationManager manager) => Windows.UI.Xaml.Markup.Primitives.MarkupWriter.GetMarkupObjectFor(@instance, @manager);
        public void Dispose() => __ProxyValue.Dispose();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}