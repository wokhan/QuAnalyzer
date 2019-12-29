namespace System.Windows
{
    using Uno.UI.Generic;

    public class StyleTypedPropertyAttribute : Proxy<global::Windows.UI.Xaml.StyleTypedPropertyAttribute>
    {
        public System.String Property
        {
            get => __ProxyValue.Property;
            set => __ProxyValue.Property = value;
        }

        public System.Type StyleTargetType
        {
            get => __ProxyValue.StyleTargetType;
            set => __ProxyValue.StyleTargetType = value;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public StyleTypedPropertyAttribute(): base()
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}