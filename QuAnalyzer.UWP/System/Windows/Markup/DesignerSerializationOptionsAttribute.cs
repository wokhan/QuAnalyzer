namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class DesignerSerializationOptionsAttribute : Proxy<global::Windows.UI.Xaml.Markup.DesignerSerializationOptionsAttribute>
    {
        public System.Windows.Markup.DesignerSerializationOptions DesignerSerializationOptions
        {
            get => __ProxyValue.DesignerSerializationOptions;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public DesignerSerializationOptionsAttribute(System.Windows.Markup.DesignerSerializationOptions @designerSerializationOptions): base(@designerSerializationOptions)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}